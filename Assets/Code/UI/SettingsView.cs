using Assets.Code.Common.Events;
using Assets.Code.Common.Settings;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _backgroundBackToMenuButton;
        [SerializeField] private Slider _mainMenuMusicSlider;
        [SerializeField] private Slider _gameMusicSlider;
        [SerializeField] private Slider _swordSlider;
        [SerializeField] private Slider _projectileSlider;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private ToggleSwitch _vibrationSwitch;
        [SerializeField] private Button _vibrationButton;


        private void Awake()
        {
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
            _backgroundBackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
            _vibrationButton.onClick.AddListener(OnVibrationPressed);
            _mainMenuMusicSlider.onValueChanged.AddListener(OnMainMenuMusicSliderValueChanged);
            _gameMusicSlider.onValueChanged.AddListener(OnGameMusicSliderValueChanged);
            _swordSlider.onValueChanged.AddListener(OnSwordSliderValueChanged);
            _projectileSlider.onValueChanged.AddListener(OnProjectileSliderValueChanged);
            _soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
        }

        
        private void Start()
        {
            SetSlidersValue();
        }

        private void SetSlidersValue()
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            float mainMenuMusicSliderValue = settingsSystem.GetMainMenuMusicIntensity();
            float gameMusicSliderValue = settingsSystem.GetGameMusicIntensity();
            float swordSliderValue = settingsSystem.GetSwordIntensity();
            float projectileSliderValue = settingsSystem.GetProjectileIntensity();
            float soundSliderValue = settingsSystem.GetSoundIntensity();

            _mainMenuMusicSlider.value = mainMenuMusicSliderValue;
            _gameMusicSlider.value = gameMusicSliderValue;
            _swordSlider.value = swordSliderValue;
            _projectileSlider.value = projectileSliderValue;
            _soundSlider.value = soundSliderValue;
        }

        private void OnMainMenuMusicSliderValueChanged(float mainMenuMusicValue)
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            settingsSystem.SaveMainMenuMusicIntensity(mainMenuMusicValue);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.VolumeChanged));
        }
        
        private void OnGameMusicSliderValueChanged(float gameMusicValue)
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            settingsSystem.SaveGameMusicIntensity(gameMusicValue);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.VolumeChanged));
        }


        private void OnSwordSliderValueChanged(float swordValue)
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            settingsSystem.SaveSwordIntensity(swordValue);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.VolumeChanged));
        }


        private void OnProjectileSliderValueChanged(float projectileValue)
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            settingsSystem.SaveProjectileIntensity(projectileValue);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.VolumeChanged));
        }


        private void OnSoundSliderValueChanged(float soundValue)
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            settingsSystem.SaveSoundIntensity(soundValue);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.VolumeChanged));
        }


        private void OnVibrationPressed()
        {
            var settingsSystem = ServiceLocator.Instance.GetService<SettingsSystem>();
            bool vibrationSwitchBool = settingsSystem.IsVibrationActived();
            _vibrationSwitch.Toggle(!vibrationSwitchBool);
            settingsSystem.SaveIfVibrationIsActived(!vibrationSwitchBool);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.IsVibrationSettingsChanged));
        }


        private void OnBackToMenuPressed()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            gameObject.SetActive(false);
        }
        public void HideFirst()
        {
            gameObject.SetActive(false);
        }
    }
}