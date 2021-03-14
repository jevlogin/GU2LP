using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class MainMenu : MonoBehaviour
    {
        #region Fields

        public AudioMixer AudioMixer;

        [SerializeField] private AudioSource _audioSourceMainMenu;
        [SerializeField] private Dropdown _dropdownScreenResolution;
        [SerializeField] private Dropdown _dropdownQualitySettings;

        [SerializeField, Header("Настройки слайдера"), Space(5)] private Slider _sliderMasterVolume;
        [SerializeField] private Slider _sliderMusicVolume;
        [SerializeField] private Slider _sliderSFXVolume;

        [SerializeField] private bool _isFullScreen;

        private Resolution[] _resolutions;
        private List<string> _resolutionsList;


        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resolutionsList = new List<string>();
            _resolutions = Screen.resolutions;
            foreach (var resolution in _resolutions)
            {
                _resolutionsList.Add(resolution.width + "*" + resolution.height);
            }
            _dropdownScreenResolution.ClearOptions();
            _dropdownScreenResolution.AddOptions(_resolutionsList);
        }

        private void Start()
        {
            _isFullScreen = Screen.fullScreen;
            SetOptionPlayerPrefabs();

            if (!_audioSourceMainMenu.isPlaying)
            {
                _audioSourceMainMenu.Play();
            }
        }

        #endregion


        #region Methods

        public void SetOptionPlayerPrefabs()
        {
            AudioMixer.GetFloat("MasterVolume", out float masterVolume);
            AudioMixer.GetFloat("MusicVolume", out float musicVolume);
            AudioMixer.GetFloat("SFXVolume", out float sFXVolume);
            _sliderMasterVolume.value = masterVolume;
            _sliderMusicVolume.value = musicVolume;
            _sliderSFXVolume.value = sFXVolume;

            _dropdownQualitySettings.value = QualitySettings.GetQualityLevel();

            //TODO подсомнением
            /*
            var tempResolution = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
            for (int index = 0; index < _resolutionsList.Count; index++)
            {
                if (string.Compare(_resolutionsList[index], tempResolution) == 0)
                {
                    _dropdownScreenResolution.value = index;
                }
            }
            */
        }

        public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        public void QuitGame() => Application.Quit();

        public void FullScreenToggle()
        {
            _isFullScreen = !_isFullScreen;
            Screen.fullScreen = _isFullScreen;
        }

        public void AudioVolumeMaster(float sliderValue)
        {
            AudioMixer.SetFloat("MasterVolume", sliderValue);
        }
        public void AudioVolumeMusic(float sliderValue)
        {
            AudioMixer.SetFloat("MusicVolume", sliderValue);
        }
        public void AudioVolumeSFX(float sliderValue)
        {
            AudioMixer.SetFloat("SFXVolume", sliderValue);
        }

        public void Quality(int value)
        {
            QualitySettings.SetQualityLevel(value);
        }

        public void Resolution(int value)
        {
            Screen.SetResolution(_resolutions[value].width, _resolutions[value].height, _isFullScreen);
        }

        #endregion

    }
}