using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Модель поля ввода
    /// </summary>
    public class InputFieldStateModel : Model
    {
        /// <summary>
        /// Данные состояния
        /// </summary>
        public string Data;

        public InputFieldStateModel(string data)
        {
            Data = data;
        }
    }
}