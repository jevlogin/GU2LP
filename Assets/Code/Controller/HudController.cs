using UnityEngine;


namespace JevLogin
{
    public sealed class HudController : IInitialization
    {
        private HpView _hpView;
        private PlayerModel _playerModel;
        private PlayerData _playerData;

        public HudController(HpView hpView, PlayerModel playerModel, PlayerData playerData)
        {
            _hpView = hpView;
            _playerModel = playerModel;
            _playerData = playerData;
        }

        public void Initialization()
        {
            _playerModel.PlayerComponents.PlayerView.CollisionDetectChange += PlayerView_CollisionDetectChange;
            _hpView._hpViewModel.IsDeads += Player_IsDeads;
        }

        private void Player_IsDeads(bool value)
        {
            RestartPositionPlayer();
        }

        private void RestartPositionPlayer()
        {
            _playerModel.PlayerComponents.SpriteRenderer.enabled = false;
            _hpView.RestartViewHp();
            _playerModel.PlayerComponents.TransformPlayer.position = _playerData.PlayerStruct.SpawnPlayer.position;
            _playerModel.PlayerComponents.SpriteRenderer.enabled = true;
        }

        private void PlayerView_CollisionDetectChange(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<ICollisionDetect>(out var collisionDetect))
            {
                _hpView._hpViewModel.ApplyDamage(collisionDetect.Damage);
            }
        }
    }
}