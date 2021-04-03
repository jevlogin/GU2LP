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
        [Header("Background and Paralax effect"), Space(5)]
        [SerializeField] private List<Transform> _backGround = new List<Transform>();

        [Header("Gun List"), Space(5)]
        [SerializeField] private List<GunView> _gunViews = new List<GunView>();

        [Header("Конфиги спрайтов. Монеты"), Space(5)]
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfigCoins;

        [Header("Списки монет и воды."), Space(5)]
        [SerializeField] private List<CoinView> _coinsList;
        [SerializeField] private List<WaterView> _listWaterViews;

        [Header("Зона смерти и выигрыша."), Space(5), SerializeField] private List<WinView> _winZonesList;

        #endregion

        private Controllers _controller;
        private Camera _camera;

        public Controllers Controller { get => _controller; set => _controller = value; }

        #endregion


        private void Awake()
        {
            _camera = Camera.main;
            _controller = new Controllers();
            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);


            var paralaxManager = new ParalaxManager(_camera.transform, _backGround);
            _controller.Add(paralaxManager);

            #region InputController

            var inputInitialization = new InputInitialization();
            _controller.Add(inputInitialization);

            _controller.Add(new InputController(inputInitialization.GetInputProxy(), inputInitialization.GetInputMouse()));

            #endregion

            var playerFactory = new PlayerFactory(_data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var cameraController = new CameraController(_camera, playerInitialization.GetPlayerModel().PlayerComponents.TransformPlayer);
            _controller.Add(cameraController);


            #region WaterController

            var waterFactory = new WaterFactory(_data.WaterData);
            _controller.Add(waterFactory);
            var waterInitialization = new WaterInitialization(waterFactory, _controller);
            _controller.Add(waterInitialization);

            var waterManager = new WaterManager(playerInitialization.GetPlayerModel(), 
                waterInitialization.GetWaterModel().WaterStruct.SpriteAnimatorControllers, _listWaterViews);
            _controller.Add(waterManager); 

            #endregion


            #region PlayerConfig

            var spritePlayerAnimatorController = new SpriteAnimatorController(playerInitialization.GetPlayerModel().PlayerSettings.SpriteAnimatorConfig);
            spritePlayerAnimatorController.StartAnimation(playerInitialization.GetPlayerModel().PlayerComponents.SpriteRenderer, AnimState.Idle, true, playerInitialization.GetPlayerModel().PlayerStruct.AnimationSpeed);
            _controller.Add(spritePlayerAnimatorController);

            var contactPoolerPlayer = new ContactPooler(playerInitialization.GetPlayerModel().PlayerComponents.Collider2D);
            _controller.Add(contactPoolerPlayer);

            var playerAnimatorController = new AnimatorController(contactPoolerPlayer, inputInitialization.GetInputProxy(), playerInitialization.GetPlayerModel(), spritePlayerAnimatorController);
            _controller.Add(playerAnimatorController);

            var playerMoveController = new PlayerMoveController(playerInitialization.GetPlayerModel(),
                inputInitialization.GetInputProxy(),
                playerInitialization.GetPlayerModel().PlayerStruct.WalkSpeed, contactPoolerPlayer);
            _controller.Add(playerMoveController);

            #endregion


            #region GunController

            var aimingMuzzle = new AimingMuzzle(_gunViews, playerInitialization.GetPlayerModel().PlayerComponents.TransformPlayer);
            _controller.Add(aimingMuzzle);

            var poolBullet = new Pool<BulletView>(10, ManagerPath.BULLET);
            var bulletPool = new BulletPool(poolBullet, _gunViews[0].PivotBulletShoot);
            var bulletInitialization = new BulletInitialization(bulletPool);
            var bulletShooterController = new GunBulletShooterController(bulletInitialization, _gunViews[0].PivotBulletShoot);
            _controller.Add(bulletShooterController);

            #endregion


            #region CoinsController

            var coinsSpriteAnimatorController = new SpriteAnimatorController(_spriteAnimatorConfigCoins);
            _controller.Add(coinsSpriteAnimatorController);

            var coinsManager = new CoinsManager(playerInitialization.GetPlayerModel(), coinsSpriteAnimatorController, _coinsList);
            _controller.Add(coinsManager);

            #endregion


            var levelComplete = new LevelCompleteManager(playerInitialization.GetPlayerModel().PlayerComponents.PlayerView,
                _listWaterViews.ToList<ICollisionDetect>(), _winZonesList.ToList<ICollisionDetect>());
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
