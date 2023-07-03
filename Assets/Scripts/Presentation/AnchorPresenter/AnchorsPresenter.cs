using System;

namespace Presentation
{
    /// <summary>
    /// Пресентер якорей
    /// </summary>
    public class AnchorsPresenter : IAnchorPresenter
    {
        private readonly AnchorsView _view;

        public AnchorsPresenter(AnchorsView view)
        {
            _view = view;
        }
        
        /// <inheritdoc />
        public void SetCountElements(int count)
        {
            _view.UpdateScale();
        }
        
        /// <inheritdoc />
        public void Destroy()
        {
        }
    }
}