using System;
using UnityEngine;
using UnityEngine.UI;
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
        
        [Space, Header("Line")] 
        [SerializeField] private Image _line;
        [SerializeField] private Color _selectColor;
        [SerializeField] private Color _deselectColor;

        /// <summary>
        /// Приложение изменило свое состяние
        /// </summary>
        public event Action<string> ApplicationStateChange;

        private void Awake()
        {
            _field.enableWordWrapping = true;
            
            _inputField.onSelect.AddListener(OnInputFieldSelect);
            _inputField.onDeselect.AddListener(OnInputFieldDeSelect);
        }

        /// <summary>
        /// Задать данные
        /// </summary>
        /// <param name="data">Данные состояния</param>
        public void SetData(string data)
        {
            _inputField.text = data;

            var color = string.IsNullOrEmpty(data) ? _deselectColor : _selectColor;
            ChangeLineColor(color);
        }
        
        private void OnInputFieldSelect(string _)
        {
            ChangeLineColor(_selectColor);
        }

        private void OnInputFieldDeSelect(string _)
        {
            ChangeLineColor(_deselectColor);
        }
        
        private void ChangeLineColor(Color color)
        {
            _line.color = color;
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
            
            _inputField.onSelect.RemoveListener(OnInputFieldSelect);
            _inputField.onDeselect.RemoveListener(OnInputFieldDeSelect);
        }
    }
}