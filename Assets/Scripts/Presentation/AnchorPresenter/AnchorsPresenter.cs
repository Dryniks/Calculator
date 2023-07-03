using System;

namespace Presentation
{
    /// <summary>
    /// Пресентер якорей
    /// </summary>
    public class AnchorsPresenter : IAnchorPresenter
    {
        private readonly AnchorsView _view;
        private readonly int _maxElementCount;

        public AnchorsPresenter(AnchorsView view, int maxElementCount)
        {
            _view = view;
            _maxElementCount = maxElementCount;
        }
        
        /// <inheritdoc />
        public void SetCountElements(int count)
        {
            var currentCount = Math.Min(count, _maxElementCount);
            _view.UpdateScale(currentCount);
        }
        
        /// <inheritdoc />
        public void Destroy()
        {
        }
    }
}