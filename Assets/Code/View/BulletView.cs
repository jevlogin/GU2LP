using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class BulletView : MonoBehaviour, ICollisionDetect
    {
        #region Fields

        [SerializeField] private TrailRenderer _trailRenderer;

        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public SpriteRenderer SpriteRenderer;
        public event Action<Collider2D> ColliderDetectChange = delegate (Collider2D collider2D) { };
        public event Action<Collision2D> CollisionDetectChange = delegate (Collision2D collision2D) { };
        public Vector3 Velocity = Vector3.zero;

        public int DamageAttack;
        public float LifeTime;

        private float _damage = 1.0f;

        #endregion


        #region Properties

        public float Damage => _damage;

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


        #region Methods

        public void SetVisible(bool value)
        {
            if (_trailRenderer)
            {
                _trailRenderer.enabled = value;
                _trailRenderer.Clear();
            }
            SpriteRenderer.enabled = value;
        }

        #endregion
    }
}
