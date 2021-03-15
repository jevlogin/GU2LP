using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ContactPooler : IExecute
    {
        #region Fields

        private ContactPoint2D[] _contactPoint2Ds = new ContactPoint2D[10];
        private readonly Collider2D _collider2D;

        private const float _collisionTresh = 0.75f;
        private int _contactCount;

        #endregion


        #region Properties

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ContactPooler(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contactPoint2Ds);


            for (int i = 0; i < _contactCount; i++)
            {
                var normal = _contactPoint2Ds[i].normal;
                var rigidBody = _contactPoint2Ds[i].rigidbody;

                if (normal.y > _collisionTresh) IsGrounded = true;

                if (normal.x > _collisionTresh) HasLeftContact = true;

                if (normal.x < -_collisionTresh) HasRightContact = true;
            }
        }

        #endregion
    }
}
