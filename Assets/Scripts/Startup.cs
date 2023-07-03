using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Data;
using Domain;
using Infrastructure;
using Presentation;

namespace Calculator
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private InputFieldStateView _inputField;
        [SerializeField] private Button _button;

        private readonly CancellationTokenSource _cts = new();
        private readonly List<IUseCaseDestroyable> _useCases = new();

        private async void Awake()
        {
            var useCases = await Task.WhenAll(CreateInputStateLayers());
            foreach (var useCase in useCases)
                _useCases.Add(useCase);
        }

        private async Task<IUseCaseDestroyable> CreateInputStateLayers()
        {
            var repository = new InputStateRepository();
            await repository.Load(_cts.Token);

            var presenter = new InputFieldStatePresenter(_inputField);
            var useCase = new InputFieldStateUseCase(repository, presenter, _cts);

            return useCase;
        }

        private void OnDestroy()
        {
            foreach (var useCase in _useCases)
                useCase.Destroy();

            _useCases.Clear();

            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}