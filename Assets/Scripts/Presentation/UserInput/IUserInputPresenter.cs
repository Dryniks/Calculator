using Infrastructure;

namespace Presentation
{
    /// <summary>
    /// Интерфейс пресендера пользовательского ввода
    /// </summary>
    public interface IUserInputPresenter : IPresenter<UserInputModel, IUserInputModelReceiver>
    {
    }
}