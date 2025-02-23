using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class ActionView : MonoBehaviour
    {
        [SerializeField]
        private Button _pauseButton;
        [SerializeField]
        private TMP_InputField _inputField;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(PressPauseButton);
            _inputField.Select();
            _inputField.ActivateInputField();
            

        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(PressPauseButton);
        }

        private void PressPauseButton()
        {
            GameEvents.OnPressPause?.Invoke();
        }
    }
}