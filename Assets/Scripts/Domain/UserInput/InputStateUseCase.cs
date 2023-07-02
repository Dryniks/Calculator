using System.Threading;
using Data;
using Infrastructure;
using Presentation;

namespace Domain
{
    public class InputStateUseCase : IInputStateEntityReceiver, IInputStateModelReceiver, IUseCaseDestroyable
    {
        // private const char ArithmeticOperation = '+';
        // private const char EqualSign = '=';
        // private const string Error = "Error";
        //
        private readonly IInputStateRepository _repository;
        private readonly IInputFieldPresenter _inputField;
        private readonly CancellationTokenSource _cts;

        // private StringBuilder _stringBuilder = new();

        public InputStateUseCase
        (
            IInputStateRepository repository,
            IInputFieldPresenter inputField,
            CancellationTokenSource cts
        )
        {
            _cts = cts;
            _repository = repository;
            _inputField = inputField;

            _repository.SetReceiver(this);
            _inputField.SetReceiver(this);
        }

        public void SetEntity(InputStateEntity entity)
        {
            var model = new InputFieldModel(entity.State);
            _inputField.SetModel(model);
        }

        public void SetModel(InputFieldModel fieldModel)
        {
            _repository.Update(fieldModel.Data, _cts.Token);
        }

        public void Destroy()
        {
            _inputField.Destroy();
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