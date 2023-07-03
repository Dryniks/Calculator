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
        [Header("Input")]
        [SerializeField] private InputFieldStateView _inputFieldStateView;
        [SerializeField] private UserInputView _userInputView;
        
        [Space(20), Header("HistoryElements")] 
        [SerializeField] private HistoryView _historyView;
        [SerializeField] private HistoryViewElement _historyViewElementPrefab;
        [SerializeField] private int _maxHistoryElements;

        [Space(20), Header("Anchors")] 
        [SerializeField] private AnchorsView _anchorsView;

        private readonly CancellationTokenSource _cts = new();
        private readonly List<IUseCaseDestroyable> _useCases = new();

        private async void Awake()
        {
            var historyRepository = new HistoryRepository();
            await historyRepository.Load(_cts.Token);

            CreateInputStateLayers();
            CreateUserInputLayers(historyRepository);
            CreateHistoryLayers(historyRepository);
            CreateAnchorLayers(historyRepository);
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

        private void CreateAnchorLayers(IHistoryElementsCountRepository repository)
        {
            var presenter = new AnchorsPresenter(_anchorsView, _maxHistoryElements);
            var useCase = new AnchorsUseCase(presenter, repository);
            
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