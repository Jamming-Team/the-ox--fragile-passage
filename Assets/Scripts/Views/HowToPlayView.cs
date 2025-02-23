using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class HowToPlayView : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton;

        private void OnEnable()
        {
            _backButton.onClick.AddListener(PressBackButton);
        }
        
        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(PressBackButton);
        }

        private void PressBackButton()
        {
            GameEvents.OnPressBack?.Invoke();
        }
    }
}