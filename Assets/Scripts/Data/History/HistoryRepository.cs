using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Репозиторий истории
    /// </summary>
    public class HistoryRepository : IHistoryRepository, IHistoryRepositoryUpdatable
    {
        private IHistoryEntityReceiver _receiver;
        private HistoryData _data;

        /// <summary>
        /// Имя файла, куда будут сохраняться данные
        /// </summary>
        private const string Name = "history.json";

        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <param name="token">Токен закрытия</param>
        public async Task Load(CancellationToken token)
        {
            _data = await Storage.Load<HistoryData>(Name, token) ?? new HistoryData();
        }

        /// <inheritdoc />
        public void SetReceiver(IHistoryEntityReceiver receiver)
        {
            _receiver = receiver;

            foreach (var element in _data.Results)
                SendEntity(element);
        }

        /// <inheritdoc />
        public async void Add(string data, CancellationToken token)
        {
            var element = new HistoryElement(data);
            _data.Results.Add(element);

            SendEntity(element);

            await Storage.Save(_data, Name, token);
        }

        private void SendEntity(HistoryElement data)
        {
            var entity = new HistoryEntity(data.Result);

            _receiver?.SetEntity(entity);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _data.Results.Clear();
            _data = null;
            _receiver = null;
        }
    }
}