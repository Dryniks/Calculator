namespace Infrastructure
{
    /// <summary>
    /// Получатель модели
    /// </summary>
    /// <typeparam name="T">Тип модели</typeparam>
    public interface IModelReceiver<in T> where T : struct
    {
        /// <summary>
        /// Задать модель
        /// </summary>
        /// <param name="model">Модель</param>
        void SetModel(T model);
    }
}