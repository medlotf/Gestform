using Gestform.Models;
using System.Collections.Concurrent;

namespace Gestform
{
    public class Program
    {
        static void Main()
        {
            var n = 10;
            var numbers = Helpers.GetRandomNumbers(n);
            var displayValues = GetDisplayValues(numbers);
            foreach(var displayValue in displayValues)
            {
                Console.WriteLine(string.Format("La valeur {0} correspond au text : {1} ", displayValue.Value, displayValue.Text));
            }
        }

        /// <summary>
        /// Retrieve the list of messages that corresponds to the list of numbers provided in the parameter
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<DisplayValueModel> GetDisplayValues(IList<int> numbers)
        {
            
            if (numbers == null)
            {
                throw new ArgumentNullException("Numbers can't be null");
            }

            var result = new ConcurrentBag<DisplayValueModel>();

            Parallel.ForEach(numbers, currentNumber =>
            {
                result.Add(new DisplayValueModel(currentNumber, GetTextByNumber(currentNumber)));
            });

            return result.ToList();
        }

        /// <summary>
        /// Retrive the text that matches the entered number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns></returns>
        public static string GetTextByNumber(int number)
        {
            var result = number switch
            {
                int i when (i % 3 == 0 && i % 5 == 0)
                    => Constants.DecisionGestform,
                int i when (i % 3 == 0)
                    => Constants.DecisionGeste,
                int i when (i % 5 == 0)
                    => Constants.DecisionForme,
                _ => number.ToString()
            };

            return result;
        }
    }
}
