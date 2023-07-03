using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Репозиторий истории
    /// </summary>
    public class HistoryRepository : IHistoryRepository, IHistoryElementsCountRepository, IHistoryRepositoryUpdatable
    {
        private IHistoryEntityReceiver _historyReceiver;
        private IHistoryEntityCountReceiver _countReceiver;
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
            _historyReceiver = receiver;

            foreach (var element in _data.Results)
                SendEntity(element);
        }
        
        /// <inheritdoc />
        public void SetReceiver(IHistoryEntityCountReceiver receiver)
        {
            _countReceiver = receiver;

            SendEntity();
        }

        /// <inheritdoc />
        public async void Add(string data, CancellationToken token)
        {
            var element = new HistoryElement(data);
            _data.Results.Add(element);

            SendEntity(element);
            SendEntity();

            await Storage.Save(_data, Name, token);
        }

        private void SendEntity(HistoryElement data)
        {
            var entity = new HistoryEntity(data.Result);

            _historyReceiver?.SetEntity(entity);
        }

        private void SendEntity()
        {
            var entity = new HistoryCountEntity(_data.Results.Count);
            
            _countReceiver?.SetEntity(entity);
        }
        
        public void Destroy()
        {
            _data.Results.Clear();
            _data = null;
            _historyReceiver = null;
        }
    }
}