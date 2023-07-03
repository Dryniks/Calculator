using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    /// <summary>
    /// Вьюшка истории
    /// </summary>
    public class HistoryView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _historyScrollView;
        [SerializeField] private Transform _bar;

        /// <summary>
        /// Трансформ контекста истории
        /// </summary>
        public Transform Content => _historyScrollView.content;

        private void Awake()
        {
            CalculateActiveScroll();
            _historyScrollView.onValueChanged.AddListener(OnScrollSizeChanged); //TODO Из контроллера не успевает просчтиать
        }

        private void OnScrollSizeChanged(Vector2 arg0)
        {
            CalculateActiveScroll();
        }

        /// <summary>
        /// Расчитать активность скролла
        /// </summary>
        private void CalculateActiveScroll()
        {
            var isActive = _historyScrollView.viewport.rect.size.y < _historyScrollView.content.rect.size.y;
            _bar.gameObject.SetActive(isActive);
            _historyScrollView.vertical = isActive;
        }

        private void OnDestroy()
        {
            _historyScrollView.onValueChanged.RemoveListener(OnScrollSizeChanged);
        }
    }
}