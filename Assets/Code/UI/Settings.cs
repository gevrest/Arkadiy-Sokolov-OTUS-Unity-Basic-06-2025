using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game
{
    public sealed class Settings : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_Dropdown _resolutionDropdown;
        [SerializeField] private TMP_Dropdown _qualityDropdown;
        [SerializeField] private Toggle _fullscreenToggle;
        [SerializeField] private Slider _soundsVolumeSlider;
        [Space(10f)]
        [SerializeField] private AudioMixer _audioMixer;
        [Space(10f)]
        [SerializeField] DefaultSettingsData _defaultSettingsData;

        private int _defaultQualityLevel;
        private bool _defaultFullscreen;
        private bool _isOpened = false;
        private Resolution[] _resolutions;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _saveButton.onClick.AddListener(SaveSettings);
            _resolutionDropdown.onValueChanged.AddListener(SetResolution);
            _qualityDropdown.onValueChanged.AddListener(SetQuality);
            _fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
            _soundsVolumeSlider.onValueChanged.AddListener(SetSoundsVolume);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
            _saveButton.onClick.RemoveListener(SaveSettings);
            _resolutionDropdown.onValueChanged.RemoveListener(SetResolution);
            _qualityDropdown.onValueChanged.RemoveListener(SetQuality);
            _fullscreenToggle.onValueChanged.RemoveListener(SetFullscreen);
            _soundsVolumeSlider.onValueChanged.RemoveListener(SetSoundsVolume);
        }

        private void Awake()
        {
            _defaultQualityLevel = _defaultSettingsData.QualityLevel;
            _defaultFullscreen = _defaultSettingsData.Fullscreen;
        }

        private void Start()
        {
            _resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            _resolutions = Screen.resolutions;
            int currentResolutionIndex = 0;

            for (int i = 0; i < _resolutions.Length; i++)
            {
                string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRate + "Hz";
                options.Add(option);

                if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            _resolutionDropdown.AddOptions(options);
            _resolutionDropdown.RefreshShownValue();
            LoadSettings(currentResolutionIndex);
        }

        public void ToggleSettings()
        {
            if (!_isOpened)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private void Open()
        {
            gameObject.SetActive(true);
            _isOpened = true;
        }

        private void Close()
        {
            gameObject.SetActive(false);
            _isOpened = false;
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetInt("QualitySettingPreference", _qualityDropdown.value);
            PlayerPrefs.SetInt("ResolutionPreference", _resolutionDropdown.value);
            PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
            PlayerPrefs.SetFloat("SoundsVolumePreference", _soundsVolumeSlider.value);
        }

        private void LoadSettings(int currentResolutionIndex)
        {
            if (PlayerPrefs.HasKey("QualitySettingPreference"))
                _qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
            else
                _qualityDropdown.value = _defaultQualityLevel;

            if (PlayerPrefs.HasKey("ResolutionPreference"))
                _resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
            else
                _resolutionDropdown.value = currentResolutionIndex;

            if (PlayerPrefs.HasKey("FullscreenPreference"))
                _fullscreenToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            else
                _fullscreenToggle.isOn = _defaultFullscreen;

            if (PlayerPrefs.HasKey("SoundsVolumePreference"))
                _soundsVolumeSlider.value = PlayerPrefs.GetFloat("SoundsVolumePreference");
            else
                _soundsVolumeSlider.value = _soundsVolumeSlider.maxValue;
        }

        private void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        private void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        private void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        private void SetSoundsVolume(float soundsVolume)
        {
            _audioMixer.SetFloat("SoundsVol", soundsVolume);
        }
    }
}