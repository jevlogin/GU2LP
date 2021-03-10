using System;
using UnityEngine;


namespace JevLogin
{
    public class PlayerView : MonoBehaviour, ICollisionDetect
    {
        public event Action<Collider2D> CollisionDetectChange = delegate (Collider2D collider2D) { };

        private void OnTriggerEnter2D(Collider2D collider)
        {
            CollisionDetectChange.Invoke(collider);
        }
    }
}