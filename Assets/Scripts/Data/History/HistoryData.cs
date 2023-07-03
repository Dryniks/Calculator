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
        public readonly List<HistoryElement> Results = new();
    }
}