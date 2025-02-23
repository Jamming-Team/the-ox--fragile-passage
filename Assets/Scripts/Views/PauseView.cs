using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _toMainMenuButton;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(PressContinueButton);
            _restartButton.onClick.AddListener(PressRestartButton);
            _toMainMenuButton.onClick.AddListener(PressToMainMenuButton);
        }
        
        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(PressContinueButton);
            _restartButton.onClick.RemoveListener(PressRestartButton);
            _toMainMenuButton.onClick.RemoveListener(PressToMainMenuButton);
        }

        private void PressContinueButton()
        {
            GameEvents.OnPressRestart?.Invoke();
        }
        
        private void PressRestartButton()
        {
            GameEvents.OnPressRestart?.Invoke();
        }
        
        private void PressToMainMenuButton()
        {
            GameEvents.OnPressToMainMenu?.Invoke();
        }
    }
}