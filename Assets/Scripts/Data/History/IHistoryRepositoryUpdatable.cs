using System.Threading;

namespace Data
{
    /// <summary> Интерфейс обновления репозитория истории </summary>
    public interface IHistoryRepositoryUpdatable
    {
        /// <summary>
        /// Добавить данные
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="token">Токен отмены</param>
        void Add(string data, CancellationToken token);
    }
}