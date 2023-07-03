namespace Presentation
{
    /// <summary>
    /// Элемент истории
    /// </summary>
    public class HistoryElement
    {
        /// <summary>
        /// Результат истории
        /// </summary>
        public readonly string Result;

        public HistoryElement(string result)
        {
            Result = result;
        }
    }
}