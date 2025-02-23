using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class PostGameView : MonoBehaviour
    {
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _toMainMenuButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(PressRestartButton);
            _toMainMenuButton.onClick.AddListener(PressToMainMenuButton);
        }
        
        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(PressRestartButton);
            _toMainMenuButton.onClick.RemoveListener(PressToMainMenuButton);
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