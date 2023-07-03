using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    /// <summary>
    /// Use case истории
    /// </summary>
    public class HistoryUseCase : IHistoryEntityReceiver, IUseCaseDestroyable
    {
        private readonly IHistoryRepository _repository;
        private readonly IHistoryPresenter _presenter;

        public HistoryUseCase
        (
            IHistoryRepository repository,
            IHistoryPresenter presenter
        )
        {
            _repository = repository;
            _presenter = presenter;

            _repository.SetReceiver(this);
        }

        /// <inheritdoc />
        public void SetEntity(HistoryEntity entity)
        {
            var result = entity.GetResult();
            _presenter.AddData(result);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _presenter.Destroy();
            _repository.Destroy();
        }
    }
}