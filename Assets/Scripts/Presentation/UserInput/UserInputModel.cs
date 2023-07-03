using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Модель пользовательского ввода
    /// </summary>
    public class UserInputModel : Model
    {
        /// <summary>
        /// Данные ввода
        /// </summary>
        public readonly string Data;

        public UserInputModel(string data)
        {
            Data = data;
        }
    }
}