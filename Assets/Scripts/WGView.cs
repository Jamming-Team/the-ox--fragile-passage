using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MoI
{
    public class WGView : MonoBehaviour
    {
        public Action<string> OnInputValueChanged; 
        
        [SerializeField]
        private TMP_Text _currentWords;
        [SerializeField]
        private TMP_InputField _inputField;

        public void Init()
        {
            _inputField.onValueChanged.AddListener(_ => OnInputValueChanged?.Invoke(_inputField.text));
            // _inputField.OnPointerClick(null);
            _inputField.Select();
            _inputField.ActivateInputField();
        }

        public void UpdateCurrentWords(List<string> words)
        {
            _currentWords.text = string.Join(", ", words);
        }

        public void ClearInputField()
        {
            _inputField.text = "";
        }

    }
}