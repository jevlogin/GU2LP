using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class LevelCompleteManager : ICleanup
    {
        private Vector3 _startPosition;
        private PlayerView _playerView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(PlayerView playerView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _playerView = playerView;
            
            _startPosition = _playerView.transform.position;
            _playerView.CollisionDetectChange += _playerView_CollisionDetectChange;

            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void _playerView_CollisionDetectChange(Collider2D collider)
        {
            if (collider.TryGetComponent(out LevelObjectView levelObjectView))
            {
                if (_deathZones.Contains(levelObjectView))
                {
                    _playerView.transform.position = _startPosition;
                }
            }
            
        }

        public void Cleanup()
        {
            _playerView.CollisionDetectChange -= _playerView_CollisionDetectChange;
        }
    }
}
