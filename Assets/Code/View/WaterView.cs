using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class WaterView : MonoBehaviour, ICollisionDetect
    {
        #region Fields

        public List<SpriteRenderer> spriteRenderers;
        public event Action<Collider2D> CollisionDetectChange = delegate (Collider2D collider2D) { };

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D colliderCollision)
        {
            CollisionDetectChange.Invoke(colliderCollision);
        }

        #endregion
    }
}