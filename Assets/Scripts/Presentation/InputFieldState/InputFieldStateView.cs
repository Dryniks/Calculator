using System;
using UnityEngine;
using TMPro;

namespace Presentation
{
    /// <summary>
    /// Вьюшка пользовательского ввода
    /// </summary>
    public class InputFieldStateView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _field;

        /// <summary>
        /// Приложение изменило свое состяние
        /// </summary>
        public event Action<string> ApplicationStateChange;

        private void Awake()
        {
            _field.enableWordWrapping = true;
        }

        /// <summary>
        /// Задать данные
        /// </summary>
        /// <param name="data">Данные состояния</param>
        public void SetData(string data)
        {
            _inputField.text = data;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
                return;

            ApplicationStateChange?.Invoke(_inputField.text);
        }

        private void OnDestroy()
        {
            ApplicationStateChange?.Invoke(_inputField.text);

            ApplicationStateChange = null;
        }
    }
}