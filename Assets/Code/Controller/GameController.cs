using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private string _dataPath;

        private Data _data;

        #region REFACTORING

        //TODO переделать
        [SerializeField] private List<Transform> _backGround = new List<Transform>();
        [SerializeField] private List<GunView> _gunViews = new List<GunView>();
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfigCoins;
        
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfigWater1;
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfigWater2;
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfigWater3;

        [SerializeField] private List<CoinView> _coinsList;
        [SerializeField] private List<WaterView> _listWaterViews;

        #endregion

        private Camera _camera;
        private Controllers _controller;

        #endregion


        private void Awake()
        {
            _camera = Camera.main;
            _controller = new Controllers();
            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);


            var paralaxManager = new ParalaxManager(_camera.transform, _backGround);
            _controller.Add(paralaxManager);

            var inputInitialization = new InputInitialization();
            _controller.Add(inputInitialization);

            var playerFactory = new PlayerFactory(_data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var cameraController = new CameraController(_camera, playerInitialization.GetPlayerModel().PlayerComponents.TransformPlayer);
            _controller.Add(cameraController);

            //TODO  Water - вынести в фабрику
            var spriteAnimatorControllerWater = new SpriteAnimatorController(_spriteAnimatorConfigWater1);
            var spriteAnimatorControllerWater2 = new SpriteAnimatorController(_spriteAnimatorConfigWater2);
            var spriteAnimatorControllerWater3 = new SpriteAnimatorController(_spriteAnimatorConfigWater3);
            _controller.Add(spriteAnimatorControllerWater);
            _controller.Add(spriteAnimatorControllerWater2);
            _controller.Add(spriteAnimatorControllerWater3);

            var listSpriteAnimatorControllerWater = new List<SpriteAnimatorController>();
            listSpriteAnimatorControllerWater.Add(spriteAnimatorControllerWater);
            listSpriteAnimatorControllerWater.Add(spriteAnimatorControllerWater2);
            listSpriteAnimatorControllerWater.Add(spriteAnimatorControllerWater3);

            var waterManager = new WaterManager(playerInitialization.GetPlayerModel(), listSpriteAnimatorControllerWater, _listWaterViews);
            _controller.Add(waterManager);
            //  End Water

            var spritePlayerAnimatorController = new SpriteAnimatorController(playerInitialization.GetPlayerModel().PlayerSettings.SpriteAnimatorConfig);
            spritePlayerAnimatorController.StartAnimation(playerInitialization.GetPlayerModel().PlayerComponents.SpriteRenderer, AnimState.Idle, true, playerInitialization.GetPlayerModel().PlayerStruct.AnimationSpeed);
            _controller.Add(spritePlayerAnimatorController);

            _controller.Add(new InputController(inputInitialization.GetInputProxy(), inputInitialization.GetInputMouse()));

            var contactPoolerPlayer = new ContactPooler(playerInitialization.GetPlayerModel().PlayerComponents.CircleCollider2D);
            _controller.Add(contactPoolerPlayer);

            var playerAnimatorController = new AnimatorController(contactPoolerPlayer, inputInitialization.GetInputProxy(), playerInitialization.GetPlayerModel(), spritePlayerAnimatorController);
            _controller.Add(playerAnimatorController);

            var playerMoveController = new PlayerMoveController(playerInitialization.GetPlayerModel(),
                inputInitialization.GetInputProxy(),
                playerInitialization.GetPlayerModel().PlayerStruct.WalkSpeed, contactPoolerPlayer);
            _controller.Add(playerMoveController);

            var aimingMuzzle = new AimingMuzzle(_gunViews, playerInitialization.GetPlayerModel().PlayerComponents.TransformPlayer);
            _controller.Add(aimingMuzzle);

            var poolBullet = new Pool<BulletView>(10, ManagerPath.BULLET);
            var bulletPool = new BulletPool(poolBullet, _gunViews[0].PivotBulletShoot);
            var bulletInitialization = new BulletInitialization(bulletPool);
            var bulletShooterController = new GunBulletShooterController(bulletInitialization, _gunViews[0].PivotBulletShoot);
            _controller.Add(bulletShooterController);

            var coinsSpriteAnimatorController = new SpriteAnimatorController(_spriteAnimatorConfigCoins);
            _controller.Add(coinsSpriteAnimatorController);

            var coinsManager = new CoinsManager(playerInitialization.GetPlayerModel(), coinsSpriteAnimatorController, _coinsList);
            _controller.Add(coinsManager);
        }

        private void Start()
        {
            _controller.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controller.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controller.FixedExecute(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controller.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controller.Cleanup();
        }
    }
}
