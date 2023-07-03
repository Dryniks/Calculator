using System;
using System.Collections.Generic;
using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Модель истории
    /// </summary>
    public class HistoryModel : Model
    {
        /// <summary>
        /// Список элементов истории
        /// </summary>
        private readonly List<HistoryElement> _elements = new();

        /// <summary>
        /// Был добавлен элемент в историю
        /// </summary>
        public event Action<HistoryElement> Added;

        /// <summary>
        /// Добавить элемент в историю
        /// </summary>
        /// <param name="data">Данные истории</param>
        public void Add(string data)
        {
            var element = new HistoryElement(data);
            _elements.Add(element);
            
            Added?.Invoke(element);
        }

        /// <summary>
        /// Уничтожить модель истории
        /// </summary>
        public void Destroy()
        {
            Added = null;
            _elements.Clear();
        }
    }
}