using System;

namespace Data
{
    /// <summary>
    /// Элемент истории вывода
    /// </summary>
    [Serializable]
    public class HistoryElement
    {
        /// <summary>
        /// Результат
        /// </summary>
        public readonly string Result;

        public HistoryElement(string result)
        {
            Result = result;
        }
    }
}