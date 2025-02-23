using System;
using TMPro;
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
        
        [SerializeField]
        private TMP_Text _outcomeText;
        [SerializeField]
        private TMP_Text _successesText;
        [SerializeField]
        private TMP_Text _failsText;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(PressRestartButton);
            _toMainMenuButton.onClick.AddListener(PressToMainMenuButton);
            
            GameEvents.OnGameWon += OnGameWon;
            GameEvents.OnGameLost += OnGameLost;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(PressRestartButton);
            _toMainMenuButton.onClick.RemoveListener(PressToMainMenuButton);
            
            GameEvents.OnGameWon -= OnGameWon;
            GameEvents.OnGameLost -= OnGameLost;
        }

        private void PressRestartButton()
        {
            GameEvents.OnPressRestart?.Invoke();
        }
        
        private void PressToMainMenuButton()
        {
            GameEvents.OnPressToMainMenu?.Invoke();
        }
        
        private void OnGameLost()
        {
            _outcomeText.text = "You Lost!";
            _successesText.text = LevelController.Instance.successesCount.ToString();
            _failsText.text = LevelController.Instance.failsCount.ToString();
        }

        private void OnGameWon()
        {
            _outcomeText.text = "YOU DID IT!";
            _successesText.text = LevelController.Instance.successesCount.ToString();
            _failsText.text = LevelController.Instance.failsCount.ToString();
        }
    }
}