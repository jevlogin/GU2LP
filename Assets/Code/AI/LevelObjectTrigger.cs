﻿using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class LevelObjectTrigger : MonoBehaviour
    {
        #region Events

        public event EventHandler<GameObject> TriggerEnter;
        public event EventHandler<GameObject> TriggerExit;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEnter?.Invoke(this, collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExit?.Invoke(this, collision.gameObject);
        }

        #endregion
    }
}