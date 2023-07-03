namespace Infrastructure
{
    /// <summary>
    /// Интерфейс пресентера с получателем
    /// </summary>
    /// <typeparam name="TModel">Модель</typeparam>
    /// <typeparam name="TReceiver">Получатель Модели</typeparam>
    public interface IPresenterWithReceiver<in TModel, in TReceiver> : IPresenter
        where TModel : Model where TReceiver : IModelReceiver<TModel>
    {
        /// <summary>
        /// Задать получателя модели
        /// </summary>
        /// <param name="receiver">Получатель модели</param>
        void SetReceiver(TReceiver receiver);
    }
}