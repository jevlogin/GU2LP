using System;
using UnityEngine;


namespace JevLogin
{
    public class LevelObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Transform Transform;
        public Rigidbody2D Rigidbody2D;

        public Action<LevelObjectView> OnLevelObjectContact = delegate (LevelObjectView levelObjectView) { };

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.GetComponent<LevelObjectView>();
            if (levelObject != null)
            {
                OnLevelObjectContact.Invoke(levelObject);
            }
        }
    }
}