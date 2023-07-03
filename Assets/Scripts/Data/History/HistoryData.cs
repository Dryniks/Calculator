using System;
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// Данные истории вывода
    /// </summary>
    [Serializable]
    public class HistoryData
    {
        /// <summary>
        /// Результаты
        /// </summary>
        public List<HistoryElement> Results = new();
    }

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