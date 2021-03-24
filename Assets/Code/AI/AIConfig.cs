using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinDistanceToTarget;
        public Transform[] Waypoints;
        internal float _minSqrDistanceToTarget;
    }
}