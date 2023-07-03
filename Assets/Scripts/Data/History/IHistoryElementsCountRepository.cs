using Infrastructure;

namespace Data
{
    /// <summary>
    /// Интерфейс репозитория с количеством элементов в истории
    /// </summary>
    public interface IHistoryElementsCountRepository : IBaseRepository<HistoryCountEntity, IHistoryEntityCountReceiver>
    {
        
    }
}