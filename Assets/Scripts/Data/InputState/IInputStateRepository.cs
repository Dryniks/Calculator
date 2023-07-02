using System.Threading;
using Infrastructure;

namespace Data
{
    /// <summary>
    /// Интерфейс репозитория состояния ввода
    /// </summary>
    public interface IInputStateRepository : IBaseRepository<InputStateEntity, IInputStateEntityReceiver>
    {
        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="token">Токен отмены</param>
        void Update(string data, CancellationToken token);
    }
}