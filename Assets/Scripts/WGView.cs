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
        public int inputLength => _inputField.text.Length;

        public void Activate()
        {
            _inputField.onValueChanged.AddListener(_ => OnInputValueChanged?.Invoke(_inputField.text));
            // _inputField.OnPointerClick(null);
            // _inputField.Select();
            // _inputField.ActivateInputField();
        }

        public void Deactivate()
        {
            _inputField.onValueChanged.RemoveListener(_ => OnInputValueChanged?.Invoke(_inputField.text));
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