using System.Threading;
using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    /// <summary>
    /// Use Case пользовательского ввода
    /// </summary>
    public class UserInputUseCase : IUserInputModelReceiver, IUseCaseDestroyable
    {
        private readonly IHistoryRepositoryUpdatable _repository;
        private readonly IUserInputPresenter _presenter;
        private readonly CancellationTokenSource _cts;

        public UserInputUseCase
        (
            IHistoryRepositoryUpdatable repository,
            IUserInputPresenter presenter,
            CancellationTokenSource cts
        )
        {
            _repository = repository;
            _presenter = presenter;
            _cts = cts;

            _presenter.SetReceiver(this);
        }

        /// <inheritdoc />
        public void SetModel(UserInputModel model)
        {
            _repository.Add(model.Data, _cts.Token);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _presenter.Destroy();
        }
    }
}