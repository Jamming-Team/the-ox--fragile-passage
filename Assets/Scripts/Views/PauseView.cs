using TMPro;
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
        
        [SerializeField]
        private TMP_Text _successesText;
        [SerializeField]
        private TMP_Text _failsText;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(PressContinueButton);
            _restartButton.onClick.AddListener(PressRestartButton);
            _toMainMenuButton.onClick.AddListener(PressToMainMenuButton);
            
            GameEvents.OnPressPause += OnPressPause;
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(PressContinueButton);
            _restartButton.onClick.RemoveListener(PressRestartButton);
            _toMainMenuButton.onClick.RemoveListener(PressToMainMenuButton);
            
            GameEvents.OnPressPause -= OnPressPause;
        }
        
        private void PressContinueButton()
        {
            GameEvents.OnPressContinue?.Invoke();
        }
        
        private void PressRestartButton()
        {
            GameEvents.OnPressRestart?.Invoke();
        }
        
        private void PressToMainMenuButton()
        {
            GameEvents.OnPressToMainMenu?.Invoke();
        }
        
        private void OnPressPause()
        {
            _successesText.text = LevelController.Instance.successesCount.ToString();
            _failsText.text = LevelController.Instance.failsCount.ToString();
        }
    }
}