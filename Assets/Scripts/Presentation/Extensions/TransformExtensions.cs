using UnityEngine;

namespace Presentation
{
    /// <summary>
    /// Расширение для трасформа
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Задать скейл по оси y
        /// </summary>
        /// <param name="transform">Трансформ</param>
        /// <param name="scaleY">Скейл по оси y</param>
        public static void SetLocalScaleY(this Transform transform, float scaleY)
        {
            var scale = transform.localScale;
            scale.y = scaleY;
            transform.localScale = scale;
        }
    }
}