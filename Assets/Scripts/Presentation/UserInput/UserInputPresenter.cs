namespace Presentation
{
    /// <summary>
    /// Пресендер пользовательского ввода
    /// </summary>
    public class UserInputPresenter : IUserInputPresenter
    {
        private readonly UserInputView _view;

        private IUserInputModelReceiver _receiver;

        public UserInputPresenter(UserInputView view)
        {
            _view = view;
            _view.ButtonClicked += OnButtonClicked;
        }

        /// <inheritdoc />
        public void SetReceiver(IUserInputModelReceiver receiver)
        {
            _receiver = receiver;
        }

        private void OnButtonClicked(string result)
        {
            var model = new UserInputModel(result);
            _receiver.SetModel(model);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _view.ButtonClicked -= OnButtonClicked;
        }
    }
}