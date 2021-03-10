using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class BulletView : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public SpriteRenderer SpriteRenderer;

        public Vector3 Velocity = Vector3.zero;

        public int DamageAttack;
        public float LifeTime;

        [SerializeField] private TrailRenderer _trailRenderer;

        public void SetVisible(bool value)
        {
            if (_trailRenderer)
            {
                _trailRenderer.enabled = value;
                _trailRenderer.Clear();
            }
            SpriteRenderer.enabled = value;
        }
    }
}
