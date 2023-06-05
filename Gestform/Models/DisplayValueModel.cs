namespace Gestform.Models
{
    public class DisplayValueModel
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public DisplayValueModel(int value, string text)
        {
            Value = value;
            Text = text;   
        }
    }
}
