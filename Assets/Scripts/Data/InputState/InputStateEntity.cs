using Infrastructure;

namespace Data
{
    /// <summary>
    /// Энтити состояния поля воода
    /// </summary>
    public class InputStateEntity : Entity
    {
        /// <summary>
        /// Данные состояния
        /// </summary>
        public readonly string State;

        public InputStateEntity(string state)
        {
            State = state;
        }
    }
}