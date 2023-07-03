using System.Threading;
using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    public class InputFieldStateUseCase : IInputStateEntityReceiver, IInputFieldStateModelReceiver, IUseCaseDestroyable
    {
        // private const char ArithmeticOperation = '+';
        // private const char EqualSign = '=';
        // private const string Error = "Error";
        //
        private readonly IInputStateRepository _repository;
        private readonly IInputFieldStatePresenter _presenter;
        private readonly CancellationTokenSource _cts;

        // private StringBuilder _stringBuilder = new();

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

        public void SetEntity(InputStateEntity entity)
        {
            _presenter.SetData(entity.State);
        }

        public void SetModel(InputFieldStateModel model)
        {
            _repository.Update(model.Data, _cts.Token);
        }

        public void Destroy()
        {
            _presenter.Destroy();
            _repository.Destroy();
        }

        // private string ModelHandler(string data)
        // {
        //     _stringBuilder.Clear();
        //     _stringBuilder.Append(data);
        //
        //     if (!data.Contains(ArithmeticOperation))
        //     {
        //         _stringBuilder.Append(EqualSign);
        //         _stringBuilder.Append(Error);
        //         return $"{_stringBuilder}";
        //     }
        // }
    }
}