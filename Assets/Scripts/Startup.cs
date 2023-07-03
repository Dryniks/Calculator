using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Data;
using Domain;
using Infrastructure;
using Presentation;

namespace Calculator
{
    /// <summary>
    /// Точка входа
    /// </summary>
    public class Startup : MonoBehaviour
    {
        [SerializeField] private InputFieldStateView _inputFieldStateView;
        [SerializeField] private UserInputView _userInputView;
        [SerializeField] private HistoryView _historyView;

        [Space] 
        [SerializeField] private HistoryViewElement _historyViewElementPrefab;
        [SerializeField] private int _maxHistoryElements;

        private readonly CancellationTokenSource _cts = new();
        private readonly List<IUseCaseDestroyable> _useCases = new();

        private async void Awake()
        {
            var historyRepository = new HistoryRepository();
            await historyRepository.Load(_cts.Token);

            CreateInputStateLayers();
            CreateUserInputLayers(historyRepository);
            CreateHistoryLayers(historyRepository);
        }

        private async void CreateInputStateLayers()
        {
            var repository = new InputStateRepository();
            await repository.Load(_cts.Token);

            var presenter = new InputFieldStatePresenter(_inputFieldStateView);
            var useCase = new InputFieldStateUseCase(repository, presenter, _cts);

            _useCases.Add(useCase);
        }

        private void CreateUserInputLayers(IHistoryRepositoryUpdatable repository)
        {
            var presenter = new UserInputPresenter(_userInputView);
            var useCase = new UserInputUseCase(repository, presenter, _cts);

            _useCases.Add(useCase);
        }

        private void CreateHistoryLayers(IHistoryRepository repository)
        {
            var presenter = new HistoryPresenter(_historyView, _historyViewElementPrefab, _maxHistoryElements);
            var useCase = new HistoryUseCase(repository, presenter);

            _useCases.Add(useCase);
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