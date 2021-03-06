using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JevLogin
{
    public sealed class LevelCompleteManager : ICleanup
    {
        private Vector3 _startPosition;
        private PlayerView _playerView;
        private List<ICollisionDetect> _deathZones;
        private List<ICollisionDetect> _winZones;

        public LevelCompleteManager(PlayerView playerView, List<ICollisionDetect> deathZones, List<ICollisionDetect> winZones)
        {
            _playerView = playerView;
            
            _startPosition = _playerView.transform.position;
            _playerView.ColliderDetectChange += _playerView_CollisionDetectChange;

            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void _playerView_CollisionDetectChange(Collider2D collider)
        {
            if (collider.TryGetComponent(out ICollisionDetect levelObjectView))
            {
                if (_deathZones.Contains(levelObjectView))
                {
                    _playerView.transform.position = _startPosition;
                }
                if (_winZones.Contains(levelObjectView))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

        public void Cleanup()
        {
            _playerView.ColliderDetectChange -= _playerView_CollisionDetectChange;
        }
    }
}
