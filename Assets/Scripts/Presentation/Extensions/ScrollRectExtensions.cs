using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    /// <summary>
    /// Расширение для скролла
    /// </summary>
    public static class ScrollRectExtensions
    {
        /// <summary>
        /// Получить высоту контента скролла
        /// </summary>
        /// <param name="scrollRect">Скролл</param>
        /// <param name="spacing">Отступ между </param>
        /// <returns>Высота контента</returns>
        public static float GetHeight(this ScrollRect scrollRect)
        {
            var group = scrollRect.content.GetComponent<HorizontalOrVerticalLayoutGroup>();
            var spacing = group == null ? 0.0f : group.spacing;

            var content = scrollRect.content;
            var childCount = content.childCount;
            var height = 0.0f;

            for (var i = 0; i < childCount; i++)
            {
                var rect = content.GetChild(i).GetComponent<RectTransform>();
                height += (rect.rect.height + spacing);
            }

            return height;
        }
    }
}