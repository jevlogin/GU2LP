using UnityEngine;

namespace JevLogin
{
    public sealed class CameraController : ILateExecute
    {
        #region Fields

        private Transform _transformPlayer;
        private Camera _camera;
        private Vector3 _offset;
        private Vector3 _desiredPosition;
        private Vector3 _smooth;

        #endregion


        #region ClassLifeCycles

        public CameraController(Camera camera, Transform transformPlayer)
        {
            _transformPlayer = transformPlayer;
            _camera = camera;
            _offset = _camera.transform.position - _transformPlayer.position;
        }

        #endregion


        #region ILateExecute

        public void LateExecute(float deltaTime)
        {
            _desiredPosition = _transformPlayer.position + _offset;
            _smooth = Vector3.Lerp(_camera.transform.position, _desiredPosition, deltaTime);
            _camera.transform.position = _smooth;
        }

        #endregion
    }
}