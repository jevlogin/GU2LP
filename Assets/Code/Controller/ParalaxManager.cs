using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace JevLogin
{
    public sealed class ParalaxManager : IExecute, IFixedExecute, IDisposable
    {
        #region Fields

        private Transform _cameraTransform;
        private List<Transform> _back;
        private List<Vector3> _backStartPosition = new List<Vector3>();
        private Vector3 _cameraStartPosition;

        private float[] _coefArray;
        private float _backgroundSize;

        private float _coef = 1.0f;

        #endregion


        #region ClassLifeCycles

        public ParalaxManager(Transform cameraTransform, List<Transform> back)
        {
            _cameraTransform = cameraTransform;
            _back = back;
            _coefArray = new float[_back.Count];

            for (int i = 0; i < _back.Count; i++)
            {
                _backStartPosition.Add(_back[i].position);
                _coefArray[i] = _coef - Random.Range(0.1f, i / 10);
            }
            _cameraStartPosition = _cameraTransform.position;

            SetBackgroundSizeFloat();
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            ParalaxBackLayers();
        }

        #endregion


        #region IFixedExecute

        public void FixedExecute(float deltaTime)
        {
            ScrollingLayers();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Паралакс эффект 
        /// </summary>
        private void ParalaxBackLayers()
        {
            for (int i = 0; i < _back.Count; i++)
            {
                _back[i].position = _backStartPosition[i] + (_cameraTransform.position - _cameraStartPosition) * _coefArray[i];
            }
        }

        /// <summary>
        /// Скроллинг слоев
        /// </summary>
        private void ScrollingLayers()
        {
            for (int i = 0; i < _back.Count; i++)
            {
                float temp = (_cameraTransform.position.x * (1 - _coefArray[i]));

                if (temp > _backStartPosition[i].x + _backgroundSize)
                {
                    _backStartPosition[i] = new Vector3(_backStartPosition[i].x + _backgroundSize, _backStartPosition[i].y, _backStartPosition[i].z);
                }
                else if (temp < _backStartPosition[i].x - _backgroundSize)
                {
                    _backStartPosition[i] = new Vector3(_backStartPosition[i].x - _backgroundSize, _backStartPosition[i].y, _backStartPosition[i].z);
                }
            }
        }

        /// <summary>
        /// Считывание размера заднего фона
        /// </summary>
        private void SetBackgroundSizeFloat()
        {
            if (_back[0].childCount >= 2)
            {
                _backgroundSize = _back[0].GetChild(2).position.x - _back[0].GetChild(1).position.x;
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _back.Clear();
            _backStartPosition.Clear();
        }

        #endregion
    }
}
