using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресендера ввода данных
    /// </summary>
    public interface IInputFieldPresenter : IPresenter<InputFieldModel, IInputStateModelReceiver>
    {
    }
}