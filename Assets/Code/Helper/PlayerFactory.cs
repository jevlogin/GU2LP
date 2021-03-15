using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerFactory
    {
        private readonly PlayerData _playerData;
        public GameObject Player;

        private PlayerModel _playerModel;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public PlayerModel CreatePlayerModel()
        {
            if (_playerModel == null)
            {
                var playerStruct = _playerData.PlayerStruct;
                var playerComponents = _playerData.PlayerComponents;
                var playerSettings = _playerData.PlayerSettingsData;

                var spawnPlayer = CreatePlayer();

                playerComponents.TransformPlayer = spawnPlayer.transform;
                playerComponents.SpriteRenderer = spawnPlayer.GetComponent<SpriteRenderer>();
                playerComponents.CircleCollider2D = spawnPlayer.GetComponent<CircleCollider2D>();
                playerComponents.RigidbodyPlayer = spawnPlayer.GetComponent<Rigidbody2D>();

                //TODO переделать
                playerComponents.LevelObjectView = spawnPlayer.gameObject.GetOrAddComponent<LevelObjectView>();
                playerComponents.PlayerView = spawnPlayer.gameObject.GetOrAddComponent<PlayerView>();

                playerComponents.RigidbodyPlayer.freezeRotation = true;
                playerComponents.SpriteRenderer.sortingOrder = playerSettings.SortingOrderSpriteRenderer;

                _playerModel = new PlayerModel(playerStruct, playerComponents, playerSettings);
            }

            return _playerModel;
        }

        public PlayerView CreatePlayer()
        {
            var _spriteSequences = _playerData.PlayerSettingsData.SpriteAnimatorConfig.SpriteSequences;
            var spriteList = from sp in _spriteSequences
                             where sp.AnimState == AnimState.Idle
                             select sp.Sprites.FirstOrDefault();
            var sprite = spriteList.FirstOrDefault();

            var player = new GameObject(ManagerPath.PLAYER)
                .AddSprite(sprite)
                .AddCircleCollider2D()
                .AddRigidbody2D()
                .AddComponent<PlayerView>();
            
            player.transform.position = _playerData.PlayerStruct.SpawnPlayer.position;

            return player;
        }
    }
}