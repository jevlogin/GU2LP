using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal class AimingMuzzle : IFixedExecute
    {
        #region Fields

        private List<GunView> _gunViews = new List<GunView>();
        private Transform _transformPlayer;

        #endregion


        #region ClassLifeCycles

        public AimingMuzzle(List<GunView> gunViews, Transform transformPlayer)
        {
            _gunViews = gunViews;
            _transformPlayer = transformPlayer;
        }

        #endregion


        #region IExecute

        public void FixedExecute(float deltaTime)
        {
            foreach (var gun in _gunViews)
            {
                var direction = _transformPlayer.position - gun.PivotBarrel.position;
                var angle = Vector3.Angle(Vector3.left, direction);
                var axis = Vector3.Cross(Vector3.left, direction);
                gun.PivotBarrel.rotation = Quaternion.AngleAxis(angle, axis);
            }
        }

        #endregion
    }
}