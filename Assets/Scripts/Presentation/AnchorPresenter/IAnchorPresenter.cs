using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресентера якорей
    /// </summary>
    public interface IAnchorPresenter : IPresenter
    {
        /// <summary>
        /// Задать количество элементов в истории
        /// </summary>
        /// <param name="count">Количество</param>
        void SetCountElements(int count);
    }
}