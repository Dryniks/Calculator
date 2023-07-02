namespace Infrastructure
{
    /// <summary>
    /// Базовый интерфейс для репозиториев
    /// </summary>
    /// <typeparam name="TEntity">Отдаваемая сущность</typeparam>
    /// <typeparam name="TReceiver">Получатель сущности</typeparam>
    public interface IBaseRepository<TEntity, in TReceiver>
        where TEntity : Entity where TReceiver : IEntityReceiver<TEntity>
    {
        /// <summary>
        /// Задать получателя
        /// </summary>
        /// <param name="receiver">Получатель</param>
        void SetReceiver(TReceiver receiver);

        /// <summary>
        /// Уничтожить репозиторий
        /// </summary>
        void Destroy();
    }
}