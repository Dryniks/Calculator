using System.Threading;
using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    /// <summary>
    /// Use case состояние ввода
    /// </summary>
    public class InputFieldStateUseCase : IInputStateEntityReceiver, IInputFieldStateModelReceiver, IUseCaseDestroyable
    {
        private readonly IInputStateRepository _repository;
        private readonly IInputFieldStatePresenter _presenter;
        private readonly CancellationTokenSource _cts;

        public InputFieldStateUseCase
        (
            IInputStateRepository repository,
            IInputFieldStatePresenter presenter,
            CancellationTokenSource cts
        )
        {
            _repository = repository;
            _presenter = presenter;
            _cts = cts;

            _repository.SetReceiver(this);
            _presenter.SetReceiver(this);
        }

        /// <inheritdoc />
        public void SetEntity(InputStateEntity entity)
        {
            _presenter.SetData(entity.State);
        }

        /// <inheritdoc />
        public void SetModel(InputFieldStateModel model)
        {
            _repository.Update(model.Data, _cts.Token);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _presenter.Destroy();
            _repository.Destroy();
        }
    }
}