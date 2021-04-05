using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class MovingPlatform : MonoBehaviour
    {
        public float Speed;
        public float MinDistance;
        public int CurrentPoint = 0;
        
        [SerializeField] private Transform[] _waypoints = new Transform[2];
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private Transform _currentTransformPoint;
        private float _minSqrDistance;


        private void Start()
        {
            _currentTransformPoint = _waypoints[CurrentPoint];
            _minSqrDistance = MinDistance * MinDistance;
        }

        private void FixedUpdate()
        {
            var direction = (_currentTransformPoint.position - (Vector3)_rigidbody2D.position).normalized;
            _rigidbody2D.velocity = direction * Speed * Time.fixedDeltaTime;

            if (((Vector3)_rigidbody2D.position - _currentTransformPoint.position).sqrMagnitude <= _minSqrDistance)
            {
                CurrentPoint = (CurrentPoint + 1) % _waypoints.Length;
                _currentTransformPoint = _waypoints[CurrentPoint];
            }
        }
    }
}