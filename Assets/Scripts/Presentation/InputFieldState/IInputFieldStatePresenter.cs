using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресендера ввода получения состояния данных
    /// </summary>
    public interface IInputFieldStatePresenter : IPresenterWithReceiver<InputFieldStateModel, IInputFieldStateModelReceiver>
    {
        /// <summary>
        /// Задать данные
        /// </summary>
        /// <param name="data">Данные</param>
        void SetData(string data);
    }
}