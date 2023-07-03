using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Presentation
{
    /// <summary>
    /// Вьюшка пользовательского ввода
    /// </summary>
    public class UserInputView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _button;

        /// <summary>
        /// Кнопка была нажата
        /// </summary>
        public event Action<string> ButtonClicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ButtonClicked?.Invoke(_inputField.text);

            _inputField.text = string.Empty;
        }

        private void OnDestroy()
        {
            ButtonClicked = null;
            _button.onClick.RemoveListener(OnButtonClick);
        }
    }
}