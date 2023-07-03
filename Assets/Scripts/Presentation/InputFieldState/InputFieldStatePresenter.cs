namespace Presentation
{
    /// <summary>
    /// Пресентер ввода данных
    /// </summary>
    public class InputFieldStatePresenter : IInputFieldStatePresenter
    {
        private readonly InputFieldStateView _view;
        private readonly InputFieldStateModel _model;

        private IInputFieldStateModelReceiver _receiver;

        public InputFieldStatePresenter(InputFieldStateView view)
        {
            _view = view;
            _view.ApplicationStateChange += OnApplicationStateChange;

            _model = new InputFieldStateModel();
            _model.Changed += OnModelChanged;
        }

        /// <inheritdoc />
        public void SetData(string data)
        {
            _model.Data = data;
        }

        /// <inheritdoc />
        public void SetReceiver(IInputFieldStateModelReceiver receiver)
        {
            _receiver = receiver;
        }

        private void OnModelChanged(string data)
        {
            _view.SetData(data);
        }

        private void OnApplicationStateChange(string result)
        {
            SetData(result);
            _receiver?.SetModel(_model);
        }

        /// <inheritdoc />
        public void Destroy()
        {
            _model.Changed -= OnModelChanged;
            _model.Destroy();

            _view.ApplicationStateChange -= OnApplicationStateChange;
        }
    }
}