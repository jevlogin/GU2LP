using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class WaterView : MonoBehaviour, ICollisionDetect
    {
        #region Fields

        public List<SpriteRenderer> spriteRenderers;

        public event Action<Collider2D> ColliderDetectChange = delegate (Collider2D collider2D) { };
        public event Action<Collision2D> CollisionDetectChange = delegate (Collision2D collision2D) { };


        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D colliderCollision)
        {
            ColliderDetectChange.Invoke(colliderCollision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionDetectChange.Invoke(collision);
        }
        #endregion
    }
}