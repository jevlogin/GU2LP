using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal class GunBulletShooterController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private readonly Transform _barrel;
        private BulletInitialization _bulletInitialization;
        private List<BulletView> _listBullets;

        private float _refireTimer = 5.3f;
        private float _fireTimer;
        private float _moveSpeed = 8.0f;
        private readonly float _maxLifeTime = 5.0f;

        #endregion


        #region ClassLifeCycles

        public GunBulletShooterController(BulletInitialization bulletInitialization, Transform pivotBulletShoot)
        {
            _bulletInitialization = bulletInitialization;
            _barrel = pivotBulletShoot;
            _fireTimer = _refireTimer;
            _listBullets = new List<BulletView>();
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            _fireTimer += deltaTime;
            BulletShoot();
            BulletControl(deltaTime);
        }

        #endregion


        #region Methods
        private void BulletControl(float deltaTime)
        {
            for (int i = 0; i < _listBullets.Count; i++)
            {
                if (_listBullets[i].isActiveAndEnabled)
                {
                    _listBullets[i].LifeTime += deltaTime;
                    if (_listBullets[i].LifeTime > _maxLifeTime)
                    {
                        _listBullets[i].LifeTime = 0.0f;
                        _bulletInitialization.GetBulletPool().ReturnToPool(_listBullets[i]);
                        _listBullets.RemoveAt(i);
                    }
                }
            }
        }

        private void BulletShoot()
        {
            if (_fireTimer >= _refireTimer)
            {
                _fireTimer = 0;
                _listBullets.Add(GetBullet());
                foreach (var bullet in _listBullets)
                {
                    bullet.Rigidbody2D.velocity = Vector2.zero;
                    bullet.Rigidbody2D.angularVelocity = 0.0f;
                    bullet.Rigidbody2D.AddForce(-_barrel.right * _moveSpeed, ForceMode2D.Impulse);
                }
            }
        }

        private BulletView GetBullet()
        {
            var bullet = _bulletInitialization.GetBulletPool().Get();
            bullet.transform.SetParent(null);
            bullet.transform.rotation = _barrel.rotation;
            bullet.transform.position = _barrel.position;

            bullet.gameObject.SetActive(true);
            return bullet;
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _listBullets.Clear();
        }

        #endregion
    }
}