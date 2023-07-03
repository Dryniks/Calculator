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

        /// <summary>
        /// Трансформ контекста истории
        /// </summary>
        public Transform Content => _historyScrollView.content;
    }
}