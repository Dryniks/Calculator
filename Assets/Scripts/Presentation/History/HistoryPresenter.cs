using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    /// <summary>
    /// Пресентер истории
    /// </summary>
    public class HistoryPresenter : IHistoryPresenter
    {
        private readonly HistoryModel _model;
        private readonly HistoryView _view;
        private readonly HistoryViewElement _prefab;
        
        private readonly int _maxElementCount;
        
        private readonly List<HistoryViewElement> _elements = new();

        public HistoryPresenter(HistoryView view, HistoryViewElement prefab, int maxElementCount)
        {
            _view = view;
            _prefab = prefab;
            _maxElementCount = maxElementCount;

            _model = new HistoryModel();
            _model.Added += OnModelAdded;
        }

        /// <inheritdoc />
        public void AddData(string data)
        {
            _model.Add(data);
        }

        private void OnModelAdded(HistoryElement data)
        {
            _elements.Add(CreateElement(data));
            _view.SetActiveScroll(_elements.Count >= _maxElementCount);
        }

        private HistoryViewElement CreateElement(HistoryElement data)
        {
            var element = Object.Instantiate(_prefab, _view.Content, true);
            var tr = element.transform;
            tr.localScale = Vector3.one;
            tr.eulerAngles = Vector3.zero;

            element.SetData(data.Result);

            return element;
        }

        /// <inheritdoc />
        public void Destroy()
        {
            foreach (var element in _elements)
                Object.Destroy(element.gameObject);

            _elements.Clear();

            _model.Added -= OnModelAdded;
            _model.Destroy();
        }
    }
}