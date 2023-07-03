using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресендера ввода получения состояния данных
    /// </summary>
    public interface IInputFieldStatePresenter : IPresenter<InputFieldStateModel, IInputFieldStateModelReceiver>
    {
    }
}