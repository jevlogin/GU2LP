using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class WinView : MonoBehaviour, ICollisionDetect
    {
        public event Action<Collider2D> CollisionDetectChange = delegate (Collider2D collider2D) { };

        private void OnTriggerEnter2D(Collider2D collisionCollider)
        {
            CollisionDetectChange.Invoke(collisionCollider);
        }
    }
}