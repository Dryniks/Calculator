using UnityEngine;

namespace Presentation
{
    /// <summary>
    /// Пресентер ввода данных
    /// </summary>
    public class InputFieldPresenter : IInputFieldPresenter
    {
        private readonly InputFieldView _view;

        private InputFieldModel _model;
        private IInputStateModelReceiver _receiver;

        public InputFieldPresenter(InputFieldView view)
        {
            _view = view;
            _view.ApplicationStateChange += OnApplicationStateChange;
        }

        /// <inheritdoc />
        public void SetModel(InputFieldModel fieldModel)
        {
            _model = fieldModel;
            _view.SetData(_model.Data);
        }

        /// <inheritdoc />
        public void SetReceiver(IInputStateModelReceiver receiver)
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