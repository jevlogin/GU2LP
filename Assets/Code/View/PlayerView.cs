using System;
using UnityEngine;


namespace JevLogin
{
    public class PlayerView : MonoBehaviour, ICollisionDetect
    {
        public event Action<Collider2D> ColliderDetectChange = delegate (Collider2D collider2D) { };
        public event Action<Collision2D> CollisionDetectChange = delegate (Collision2D collision2D) { };
        public float Damage => _damage;
        private float _damage = 1.0f;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            ColliderDetectChange.Invoke(collider);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionDetectChange.Invoke(collision);
        }
    }
}