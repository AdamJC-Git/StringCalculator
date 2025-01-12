
namespace StringCalculation.Extensions
{
    public static class StringExtensions
    {
        //remove the delimiters from string so we can perform sum and validation operations
        public static string RemoveDelimiterCharacters(this string numbers, int numberOfDelimiters)
            => numbers.Substring(2 + numberOfDelimiters).Replace("\n", "");


        //get the delimiter/s for the string of numbers (default delimiters are comma and new line)
        public static string[] GetDelimiters(this string numbers)
        {
            string[] delimiters;

            if (numbers.Substring(0, 2) == "//")
            {
                List<string> items = new List<string>();
                var numbersStart = numbers.IndexOf("\n");
                var delimiterValues = numbers.Substring(2, numbersStart - 2);
                foreach (var character in delimiterValues)
                {
                    items.Add(character.ToString());
                }
                delimiters = items.ToArray();
            }
            else
            {
                delimiters = new[] { ",", Environment.NewLine, "\n" };
            }

            return delimiters;
        }
    }
}

