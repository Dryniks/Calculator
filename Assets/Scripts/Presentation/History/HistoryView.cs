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

        public void SetScrollData(bool enable)
        {
            _bar.gameObject.SetActive(enable);
            _historyScrollView.vertical = enable;
        }
    }
}