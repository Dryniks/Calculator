using System.Collections.Generic;
using System.Text;
using Infrastructure;

namespace Data
{
    /// <summary>
    /// Энтити истории
    /// </summary>
    public class HistoryEntity : Entity
    {
        /// <summary>
        /// Символ арифмитической операции
        /// </summary>
        private const char ArithmeticOperation = '+';

        /// <summary>
        /// Символ знака равно
        /// </summary>
        private const char EqualSign = '=';

        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        private const string Error = "Error";

        /// <summary>
        /// Данные энтити
        /// </summary>
        private readonly string _data;

        private readonly StringBuilder _stringBuilder = new();

        public HistoryEntity(string data)
        {
            _data = data;
        }

        /// <summary>
        /// Получить результат математической операции
        /// </summary>
        /// <returns>Результат</returns>
        public string GetResult()
        {
            if (!_data.Contains(ArithmeticOperation))
                return GetErrorMessage();

            var numbers = GetNumbers();
            if (numbers == null)
                return GetErrorMessage();

            var result = 0;
            foreach (var number in numbers)
                result += number;

            _stringBuilder.Clear();
            _stringBuilder.Append(_data);
            _stringBuilder.Append(EqualSign);
            _stringBuilder.Append($"{result}");

            return $"{_stringBuilder}";
        }

        private List<int> GetNumbers()
        {
            var list = new List<int>();

            var numbers = _data.Split(ArithmeticOperation);
            foreach (var number in numbers)
            {
                if (!int.TryParse(number, out var element))
                    return null;

                list.Add(element);
            }

            return list;
        }

        private string GetErrorMessage()
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(_data);
            _stringBuilder.Append(EqualSign);
            _stringBuilder.Append(Error);
            return $"{_stringBuilder}";
        }
    }
}