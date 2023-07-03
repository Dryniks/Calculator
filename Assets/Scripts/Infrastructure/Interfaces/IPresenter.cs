namespace Infrastructure
{
    /// <summary>
    /// Интерфейс пресентера
    /// </summary>
    /// <typeparam name="TModel">Модель</typeparam>
    /// <typeparam name="TReceiver">Получатель модели</typeparam>
    public interface IPresenter
    {
        /// <summary>
        /// Уничтожить пресентер
        /// </summary>
        void Destroy();
    }
}