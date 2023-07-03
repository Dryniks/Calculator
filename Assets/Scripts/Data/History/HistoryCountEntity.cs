using Infrastructure;

namespace Data
{
    /// <summary>
    /// Энтити с количеством элементов в истории
    /// </summary>
    public class HistoryCountEntity : Entity
    {
        /// <summary>
        /// Количество элементов в истории
        /// </summary>
        public readonly int Count;

        public HistoryCountEntity(int count)
        {
            Count = count;
        }
    }
}