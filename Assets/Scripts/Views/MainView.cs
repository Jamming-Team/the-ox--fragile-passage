using System;
using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class MainView : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;
        [SerializeField]
        private Button _howToPlayButton;
        [SerializeField]
        private Button _settingsButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(PressStartButton);
            _howToPlayButton.onClick.AddListener(PressHowToPlayButton);
            _settingsButton.onClick.AddListener(PressSettingsButton);
        }
        
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(PressStartButton);
            _howToPlayButton.onClick.RemoveListener(PressHowToPlayButton);
            _settingsButton.onClick.RemoveListener(PressSettingsButton);
        }

        private void PressStartButton()
        {
            GameEvents.OnPressStart?.Invoke();
        }
        
        private void PressHowToPlayButton()
        {
            GameEvents.OnPressHowToPlay?.Invoke();
        }
        
        private void PressSettingsButton()
        {
            GameEvents.OnPressSettings?.Invoke();
        }
    }
}