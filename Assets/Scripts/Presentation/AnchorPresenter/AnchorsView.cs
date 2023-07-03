using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    /// <summary>
    /// Вьюшка якорей
    /// </summary>
    public class AnchorsView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private List<Transform> _anchors;
        [SerializeField] private Transform _upperAnchor;
        [SerializeField] private Transform _scroll;

        private float StartSizeY;

        private void Awake()
        {
            StartSizeY = _rectTransform.rect.size.y;
        }

        /// <summary>
        /// Обновить скейлы
        /// </summary>
        public void UpdateScale()//TODO РАссчет!!!
        {
            Debug.LogError($"{_scrollRect.content.rect.size.y} {_scrollRect.viewport.rect.y}");
            var minSize = Math.Min(_scrollRect.content.rect.size.y, Math.Abs(_scrollRect.viewport.rect.y));
            Debug.LogError($"{minSize} {StartSizeY}");
            var percentSizeY = (StartSizeY + minSize) / StartSizeY;
            var scale = transform.localScale;
            scale.y = percentSizeY;
            transform.localScale = scale;

            foreach (var anchor in _anchors)
            {
                var anchorScale = anchor.localScale;
                anchorScale.y = 1 / scale.y;
                anchor.localScale = anchorScale;
            }

            _scroll.position = _upperAnchor.transform.position;

            var scrollScale = _scroll.localScale;
            scrollScale.y = 1 / scale.y;
            _scroll.localScale = scrollScale;
        }
    }
}