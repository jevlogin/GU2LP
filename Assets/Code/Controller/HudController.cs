using UnityEngine;


namespace JevLogin
{
    public sealed class HudController : IExecute, IInitialization
    {
        private HpView _hpView;
        private PlayerModel _playerModel;

        public HudController(HpView hpView, PlayerModel playerModel)
        {
            _hpView = hpView;
            _playerModel = playerModel;
        }

        public void Execute(float deltaTime)
        {

        }

        public void Initialization()
        {
            _playerModel.PlayerComponents.PlayerView.CollisionDetectChange += PlayerView_CollisionDetectChange;
        }

        private void PlayerView_CollisionDetectChange(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<BulletView>(out var bulletView))
            {
                _hpView._hpViewModel.ApplyDamage(bulletView.DamageAttack);
            }
        }
    }
}