using UnityEngine;


namespace JevLogin
{
    public sealed class PatrolAIModel
    {
        #region Fields

        private readonly Transform[] _protectorWaypoints;
        private int _currentPointIndex;

        #endregion


        #region ClassLifeCycles

        public PatrolAIModel(Transform[] protectorWaypoints)
        {
            _protectorWaypoints = protectorWaypoints;
            _currentPointIndex = 0;
        }

        #endregion


        #region Methods

        public Transform GetNextTarget()
        {
            if (_protectorWaypoints == null)
            {
                return null;
            }
            _currentPointIndex = (_currentPointIndex + 1) % _protectorWaypoints.Length;
            return _protectorWaypoints[_currentPointIndex];
        }

        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_protectorWaypoints == null)
            {
                return null;
            }
            var closestIndex = 0;
            var closestDistance = 0.0f;
            //TODO использовать отношение величин sqrMagnitude

            for (int i = 0; i < _protectorWaypoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _protectorWaypoints[i].position);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;
            return _protectorWaypoints[_currentPointIndex];
        }

        #endregion
    }
}