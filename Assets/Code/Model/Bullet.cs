using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : IExecute
    {
        private float _radius = 0.3f;
        private Vector3 _velocity;
        private float _groundLevel = 0;
        private float _g = Physics.gravity.y;

        private BulletView _bulletView;

        public Bullet(BulletView bulletView)
        {
            _bulletView = bulletView;
            //_bulletView.SetVisible(false);
        }

        public void Execute(float deltaTime)
        {
            if (IsGrounded())
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _bulletView.transform.position = _bulletView.transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + Vector3.up * _g * deltaTime);
                _bulletView.transform.position += _velocity * deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.transform.position = position;
            SetVelocity(velocity);
            _bulletView.SetVisible(true);
        }

        private void SetVelocity(Vector3 valueVelocity)
        {   
            _velocity = valueVelocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _bulletView.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return _bulletView.transform.position.y <= _groundLevel + _radius + float.Epsilon && _velocity.y <= 0;
        }
    }
}
