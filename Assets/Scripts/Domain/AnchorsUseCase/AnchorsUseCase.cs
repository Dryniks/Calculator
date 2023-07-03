using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    /// <summary>
    /// Use case якорей
    /// </summary>
    public class AnchorsUseCase : IHistoryEntityCountReceiver, IUseCaseDestroyable
    {
        private readonly IAnchorPresenter _presenter;

        public AnchorsUseCase(IAnchorPresenter presenter, IHistoryElementsCountRepository repository)
        {
            _presenter = presenter;
            
            repository.SetReceiver(this);
        }

        /// <inheritdoc />
        public void SetEntity(HistoryCountEntity entity)
        {
            _presenter.SetCountElements(entity.Count);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _presenter.Destroy();
        }
    }
}