using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Репозиторий состояний
    /// </summary>
    public class InputStateRepository : IInputStateRepository
    {
        private IInputStateEntityReceiver _receiver;
        private InputStateData _data;

        private const string Name = "state.json";

        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <param name="token">Токен закрытия</param>
        public async Task Load(CancellationToken token)
        {
            _data = await Storage.Load<InputStateData>(Name, token) ?? new InputStateData();
        }

        /// <inheritdoc />
        public void SetReceiver(IInputStateEntityReceiver receiver)
        {
            _receiver = receiver;
            SendEntity();
        }

        /// <inheritdoc />
        public async void Update(string data, CancellationToken token)
        {
            _data.State = data;
            SendEntity();

            await Storage.Save(_data, Name, token);
        }

        private void SendEntity()
        {
            var entity = new InputStateEntity(_data.State);
            _receiver.SetEntity(entity);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _data = null;
        }
    }
}