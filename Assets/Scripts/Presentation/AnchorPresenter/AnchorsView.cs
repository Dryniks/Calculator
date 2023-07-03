using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    /// <summary>
    /// Вьюшка якорей
    /// </summary>
    public class AnchorsView : MonoBehaviour
    {
        [SerializeField] private List<Transform> _anchors;
        [SerializeField] private float _step;

        /// <summary>
        /// Обновить скейлы
        /// </summary>
        /// <param name="count">Количество элементов истории</param>
        public void UpdateScale(int count)
        {
            var scale = transform.localScale;
            scale.y = 1 + count * _step;
            transform.localScale = scale;

            foreach (var anchor in _anchors)
            {
                var anchorScale = anchor.localScale;
                anchorScale.y = 1 / scale.y;
                anchor.localScale = anchorScale;
            }
        }
    }
}