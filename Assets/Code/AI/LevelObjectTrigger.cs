using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class LevelObjectTrigger : MonoBehaviour
    {
        #region Events

        public event EventHandler<GameObject> TriggerEnter = delegate (object sender, GameObject eventArgs) { };
        public event EventHandler<GameObject> TriggerExit = delegate (object sender, GameObject eventArgs) { };

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEnter.Invoke(this, collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExit.Invoke(this, collision.gameObject);
        }

        #endregion
    }
}