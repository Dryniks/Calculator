using Infrastructure;

namespace Data
{
    /// <summary>
    /// Получатель энтити истории вывода результатов
    /// </summary>
    public interface IHistoryEntityReceiver : IEntityReceiver<HistoryEntity>
    {
    }
}