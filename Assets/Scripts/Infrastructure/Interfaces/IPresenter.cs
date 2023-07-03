namespace Infrastructure
{
    /// <summary>
    /// Интерфейс пресентера
    /// </summary>
    /// <typeparam name="TModel">Модель</typeparam>
    /// <typeparam name="TReceiver">Получатель модели</typeparam>
    public interface IPresenter<in TModel, in TReceiver> where TModel : Model where TReceiver : IModelReceiver<TModel>
    {
        /// <summary>
        /// Задать модель
        /// </summary>
        /// <param name="model">Модель</param>
        void SetModel(TModel model);

        /// <summary>
        /// Задать получателя модели
        /// </summary>
        /// <param name="receiver">Получатель модели</param>
        void SetReceiver(TReceiver receiver);

        /// <summary>
        /// Уничтожить пресентер
        /// </summary>
        void Destroy();
    }
}