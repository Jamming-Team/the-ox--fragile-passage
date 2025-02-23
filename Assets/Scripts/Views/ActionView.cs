using UnityEngine;
using UnityEngine.UI;

namespace MoI
{
    public class ActionView : MonoBehaviour
    {
        [SerializeField]
        private Button _pauseButton;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(PressPauseButton);
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