using UnityEngine;
using TMPro;

namespace Presentation
{
    /// <summary>
    /// Вьюшка элемента истории
    /// </summary>
    public class HistoryViewElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        /// <summary>
        /// Задать данные
        /// </summary>
        /// <param name="data">Данные</param>
        public void SetData(string data)
        {
            _label.text = data;
        }
    }
}