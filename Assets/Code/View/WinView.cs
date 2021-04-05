using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class WinView : MonoBehaviour, ICollisionDetect
    {
        #region Properties

        public float Damage => _damage;

        #endregion

        #region Fields

        private float _damage = 1.0f;

        public event Action<Collider2D> ColliderDetectChange = delegate (Collider2D collider2D) { };
        public event Action<Collision2D> CollisionDetectChange = delegate (Collision2D collision) { };

        #endregion


        #region ICollisionDetect

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ColliderDetectChange.Invoke(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionDetectChange.Invoke(collision);
        }

        #endregion
    }
}