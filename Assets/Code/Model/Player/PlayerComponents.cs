using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public class PlayerComponents
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D CircleCollider2D;
        public Transform TransformPlayer;
        public Rigidbody2D RigidbodyPlayer;

        //TODO переделать потом
        public LevelObjectView LevelObjectView;
        public PlayerView PlayerView;
    }
}