using Pathfinding;
using UnityEngine;

namespace JevLogin
{
    public sealed class StalkerAIModel
    {
        #region Fields

        private readonly AIConfig _config;
        private Path _path;
        private int _currentPointIndex;

        #endregion


        #region ClassLifeCycles

        public StalkerAIModel(AIConfig stalkerAIConfig)
        {
            _config = stalkerAIConfig;
            _config._minSqrDistanceToTarget = _config.MinDistanceToTarget * _config.MinDistanceToTarget;
        }

        #endregion


        #region Methods

        public void UpdatePath(Path path)
        {
            _path = path;
            _currentPointIndex = 0;
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            if (_path == null)
            {
                return Vector2.zero;
            }
            if (_currentPointIndex >= _path.vectorPath.Count)
            {
                return Vector2.zero;
            }

            var direction = ((Vector2)_path.vectorPath[_currentPointIndex] - fromPosition).normalized;
            var result = _config.Speed * direction;
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_path.vectorPath[_currentPointIndex] - fromPosition);

            if (sqrDistance <= _config._minSqrDistanceToTarget)
            {
                _currentPointIndex++;
            }

            return result;
        }

        #endregion
    }
}