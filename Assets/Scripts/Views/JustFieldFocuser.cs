using System;
using TMPro;
using UnityEngine;

namespace MoI
{
    public class JustFieldFocuser : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _inputField;

        private void OnEnable()
        {
            _inputField.Select();
            _inputField.ActivateInputField();
        }
    }
}