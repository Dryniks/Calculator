using UnityEngine;

namespace Presentation
{
    /// <summary>
    /// Пресентер ввода данных
    /// </summary>
    public class InputFieldStatePresenter : IInputFieldStatePresenter
    {
        private readonly InputFieldStateView _view;

        private InputFieldStateModel _model;
        private IInputFieldStateModelReceiver _receiver;

        public InputFieldStatePresenter(InputFieldStateView view)
        {
            _view = view;
            _view.ApplicationStateChange += OnApplicationStateChange;
        }

        /// <inheritdoc />
        public void SetModel(InputFieldStateModel fieldModel)
        {
            _model = fieldModel;
            _view.SetData(_model.Data);
        }

        /// <inheritdoc />
        public void SetReceiver(IInputFieldStateModelReceiver receiver)
        {
            _receiver = receiver;
        }

        private void OnApplicationStateChange(string result)
        {
            _model.Data = result;
            _receiver.SetModel(_model);
        }

        /// <summary>
        /// Уничтожить пресентер
        /// </summary>
        public void Destroy()
        {
            Object.Destroy(_view.gameObject);
            _view.ApplicationStateChange -= OnApplicationStateChange;
        }
    }
}