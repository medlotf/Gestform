namespace Gestform
{
    public static class Helpers
    {
        /// <summary>
        /// Retrive Random Numbers
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<int> GetRandomNumbers(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentNullException("Number can't be less than zero");
            }

            var numbers = new List<int>();
            Random random = new();

            for (int i = 0; i < number; i++)
            {
                int randomNumber = random.Next(-1000, 1001);
                numbers.Add(randomNumber);
            }

            return numbers;
        }
    }
}
