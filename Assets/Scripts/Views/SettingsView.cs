using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton;
        
        [SerializeField]
        private Slider _musicVolumeScrollbar;
        [SerializeField]
        private Slider _SFXVolumeScrollbar;
        
        [SerializeField]
        private Slider _minTempValueScrollbar;
        [SerializeField]
        private TMP_Text _minTempValueText;
        [SerializeField]
        private Slider _victoryTimerScrollbar;
        [SerializeField]
        private TMP_Text _victoryTimerText;
        

        private void OnEnable()
        {
            _backButton.onClick.AddListener(PressBackButton);
            
            _musicVolumeScrollbar.onValueChanged.AddListener(MusicVolumeChanged);
            _SFXVolumeScrollbar.onValueChanged.AddListener(SFXVolumeChanged);
            
            _minTempValueScrollbar.onValueChanged.AddListener(TempValueChanged);
            _victoryTimerScrollbar.onValueChanged.AddListener(VictoryTimerValueChanged);
            
            FillSettings();
        }
        
        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(PressBackButton);
            
            _musicVolumeScrollbar.onValueChanged.RemoveListener(MusicVolumeChanged);
            _SFXVolumeScrollbar.onValueChanged.RemoveListener(SFXVolumeChanged);
            
            _minTempValueScrollbar.onValueChanged.RemoveListener(TempValueChanged);
            _victoryTimerScrollbar.onValueChanged.RemoveListener(VictoryTimerValueChanged);
        }

        private void PressBackButton()
        {
            GameEvents.OnPressBack?.Invoke();
        }


        private void MusicVolumeChanged(float value)
        {
            GameEvents.OnChangeMusicVolume?.Invoke(value);
        }
        
        private void SFXVolumeChanged(float value)
        {
            GameEvents.OnChangeSFXVolume?.Invoke(value);
        }

        private void TempValueChanged(float value)
        {
            GameEvents.OnChangeMinTempValue?.Invoke(value);
            _minTempValueText.text = value + " \u00b0C";
        }
        
        private void VictoryTimerValueChanged(float value)
        {
            GameEvents.OnChangeVictoryTimer?.Invoke(value);
            _victoryTimerText.text = value + " sec.";
        }

        
        private void FillSettings()
        {
            var data = LevelController.Instance.settingsController._data;

            _musicVolumeScrollbar.value = data.musicVolume;
            _SFXVolumeScrollbar.value = data.SFXVolume;
            
            _minTempValueScrollbar.value = data.gameMinTemp;
            _minTempValueText.text = data.gameMinTemp + " \u00b0C";

            _victoryTimerScrollbar.value = data.victoryTimer;
            _victoryTimerText.text = data.victoryTimer + " sec.";
        }
    }
}