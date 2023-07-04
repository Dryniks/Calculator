using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    /// <summary>
    /// Скейлер
    /// </summary>
    public class ScaleResizer : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private List<Transform> _anchors;
        [SerializeField] private Transform _upperAnchor;
        [SerializeField] private Transform _scroll;

        private float _startSizeY;
        private int _elementCount;

        private const float ScaleFactor = 4;

        private void Awake()
        {
            _startSizeY = _rectTransform.rect.size.y;
        }

        private void Update()
        {
            var childCount = _scrollRect.content.childCount;
            if (childCount == _elementCount)
                return;

            _elementCount = childCount;

            var contentHeight = _scrollRect.GetHeight();
            var viewportHeight = _scrollRect.viewport.rect.size.y;
            var minHeight = Math.Min(contentHeight, viewportHeight);
            var sizeY = (_startSizeY + minHeight * ScaleFactor) / _startSizeY;
            var delta = 1 / sizeY;
            transform.SetLocalScaleY(sizeY);

            foreach (var anchor in _anchors)
                anchor.SetLocalScaleY(delta);

            _scroll.position = _upperAnchor.transform.position;
            _scroll.SetLocalScaleY(delta);
        }
    }
}