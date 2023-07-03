using Infrastructure;

namespace Data
{
    /// <summary>
    /// Энтити истории
    /// </summary>
    public class HistoryEntity : Entity
    {
        /// <summary>
        /// Данные энтити
        /// </summary>
        public readonly string Data;

        public HistoryEntity(string data)
        {
            Data = data;
        }
    }
}