using System;
using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Модель поля ввода
    /// </summary>
    public class InputFieldStateModel : Model
    {
        private string _data;

        /// <summary>
        /// Данные изменены
        /// </summary>
        public event Action<string> Changed;

        /// <summary>
        /// Данные состояния
        /// </summary>
        public string Data
        {
            get => _data;
            set
            {
                if (!string.IsNullOrEmpty(_data) && _data.Equals(value))
                    return;

                _data = value;
                Changed?.Invoke(_data);
            }
        }

        /// <summary>
        /// Уничтожить модель
        /// </summary>
        public void Destroy()
        {
            Changed = null;
        }
    }
}