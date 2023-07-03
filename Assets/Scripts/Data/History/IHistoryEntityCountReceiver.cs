using Infrastructure;

namespace Data
{
    /// <summary>
    /// Получатель количества элементов в истории
    /// </summary>
    public interface IHistoryEntityCountReceiver : IEntityReceiver<HistoryCountEntity>
    {
    }
}