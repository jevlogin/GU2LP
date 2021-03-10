using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class LevelObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Transform Transform;
        public Rigidbody2D Rigidbody;

        public Action<LevelObjectView> OnLevelObjectContact = delegate (LevelObjectView levelObjectView) { };

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.GetComponent<LevelObjectView>();
            OnLevelObjectContact.Invoke(levelObject);
        }
    }
}