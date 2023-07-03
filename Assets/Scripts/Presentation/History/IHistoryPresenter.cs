using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресентера истории
    /// </summary>
    public interface IHistoryPresenter : IPresenter
    {
        /// <summary>
        /// Добавить данные
        /// </summary>
        /// <param name="data">Данные</param>
        void AddData(string data);
    }
}