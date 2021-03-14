using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class PauseMenu : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _panelPauseMenu;
        [SerializeField] private AudioSource _audioSourceInGameProcess;

        private GameObject _currentPauseMenu;

        private bool _isActive = false;

        #endregion


        #region Properties

        public GameObject CurrentPauseMenu { get => _currentPauseMenu; set => _currentPauseMenu = value; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            CurrentPauseMenu = _panelPauseMenu;
        }

        private void Update()
        {
            if (Input.GetButtonDown(ManagerAxis.CANCEL))
            {
                _isActive = !_isActive;
                OnApplicationPause(_isActive);
            }
        }

        #endregion

        public void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                _isActive = true;   //TODO подсомнением

                if (_audioSourceInGameProcess.isPlaying)
                {
                    _audioSourceInGameProcess.Pause();
                    Debug.Log($"Должна поставиться пауза");
                }

                CurrentPauseMenu.SetActive(_isActive);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _isActive = false;   //TODO подсомнением
                Time.timeScale = 1;
                if (!_audioSourceInGameProcess.isPlaying)
                {
                    _audioSourceInGameProcess.Play();
                }
                CurrentPauseMenu.SetActive(_isActive);
            }
        }

        public void SwitchCurrentPausePanelMenu(GameObject panelMenu)
        {
            CurrentPauseMenu = panelMenu;
        }
    }
}