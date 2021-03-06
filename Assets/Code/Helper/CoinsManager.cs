using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class CoinsManager : IEmptyInitialization, ICleanup
    {
        private const float _animationSpeed = 10.0f;

        private PlayerView _playerView;
        private SpriteAnimatorController _spriteAnimatorController;
        private List<CoinView> _coinViews = new List<CoinView>();

        public CoinsManager(PlayerModel playerModel, SpriteAnimatorController spriteAnimatorController, List<CoinView> coinViews)
        {
            _playerView = playerModel.PlayerComponents.PlayerView;
            _spriteAnimatorController = spriteAnimatorController;
            _coinViews = coinViews;
            _playerView.ColliderDetectChange += _playerView_ColliderDetectChange;

            foreach (var coinView in _coinViews)
            {
                _spriteAnimatorController.StartAnimation(coinView.SpriteRenderer, AnimState.Run, true, _animationSpeed);
            }
        }

        private void _playerView_ColliderDetectChange(Collider2D collider)
        {
            if (collider.TryGetComponent(out CoinView coinView))
            {
                if (_coinViews.Contains(coinView))
                {
                    _spriteAnimatorController.StopAnimation(coinView.SpriteRenderer);
                    Object.Destroy(coinView.gameObject);
                }
            }

        }
      
        public void Cleanup()
        {
            _playerView.ColliderDetectChange -= _playerView_ColliderDetectChange;
        }
    }
}
