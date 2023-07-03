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
            SetActiveScroll(false);
        }

        /// <summary>
        /// Задать активность скроллу
        /// </summary>
        /// <param name="isActive">Активен ли</param>
        public void SetActiveScroll(bool isActive)
        {
            _bar.gameObject.SetActive(isActive);
            _historyScrollView.vertical = isActive;
        }
    }
}