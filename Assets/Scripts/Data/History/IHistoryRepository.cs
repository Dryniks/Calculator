using Infrastructure;

namespace Data
{
    /// <summary>
    /// Интерфейс репозитория истории
    /// </summary>
    public interface IHistoryRepository : IBaseRepository<HistoryEntity, IHistoryEntityReceiver>
    {
    }
}