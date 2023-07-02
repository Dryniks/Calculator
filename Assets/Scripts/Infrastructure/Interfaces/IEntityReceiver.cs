namespace Infrastructure
{
    /// <summary>
    /// Получатель энтити
    /// </summary>
    /// <typeparam name="T">Тип энтити</typeparam>
    public interface IEntityReceiver<in T> where T : Entity
    {
        /// <summary>
        /// Задать энтити
        /// </summary>
        /// <param name="entity">Энтити</param>
        void SetEntity(T entity);
    }
}