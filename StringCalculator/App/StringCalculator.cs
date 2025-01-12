using StringCalculation.App.Interface;
using StringCalculation.Extensions;

namespace StringCalculation.App
{
    public class StringCalculator : IStringCalculator
    {
        /// <summary>
        /// method to add and calculate sum of a string of numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Add(string numbers)
        {
            //validate that string is not empty, if empty then return 0
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            //validate that last value in string is not \n
            ValidateLastIndexValue(numbers);               

            //get the Delimiters required from GetDelimiters extension method
            var delimiters = numbers.GetDelimiters();      
            
            //remove unneeded characters
            if(numbers.Substring(0,2) == "//")
            {
                //get count of delimiters and use extension method to remove excess characters from string
                int numberOfDelimiters = delimiters.Count();
                numbers = numbers.RemoveDelimiterCharacters(numberOfDelimiters);
            }

            //split the number string based upon delimiters
            var numbersSplit = numbers.Split(delimiters, StringSplitOptions.None);

            int sum = 0;
            //Performance issue - if working with very large lists, declare list size if possible else the list will
            //need to be resized many times affecting performance
            List<int> intNumbersList = new List<int>(numbersSplit.Count());

            foreach (var num in numbersSplit)
            {
                int numberValue = ValidateNumber(num);
                intNumbersList.Add(numberValue);
                sum += numberValue;             
            }

            //validate for negative numbers and if any negatives then throw an exception
            ValidateForNegativeNumbers(intNumbersList);            

            return sum;
        }

        //validate to check that the last value of string is not \n.
        private void ValidateLastIndexValue(string numbers)
        {
            char lastIndex = numbers[numbers.Count() - 1];
            if (lastIndex == '\n')
                throw new Exception($"Invalid input, there needs to be a number after line break");            
        }

        //validate the values from the input string
        private int ValidateNumber(string number)
        {
            //check that value is a valid numeric value and convert to integer
            bool isNumber = int.TryParse(number, out int intNumber);
            if(!isNumber)
                throw new Exception($"An invalid number value was entered: {number}");

            //ignore any values over 1000
            if(intNumber > 1000)
                intNumber = 0;            

            return intNumber;
        }

        //Validate for any negative numbers
        private void ValidateForNegativeNumbers(IEnumerable<int> intNumbersList)
        {
            //if any negative values then throw an error "Negatives not allowed" and display negative numbers in
            //exception message
            var negativeNumbersList = intNumbersList.Where(n => n < 0).ToList();
            if (negativeNumbersList.Count() > 0)
            {
                string negatives = "";
                foreach (var negative in negativeNumbersList)
                {
                    negatives += negative.ToString() + ",";
                }

                negatives = negatives.Substring(0, negatives.Length - 1);

                throw new Exception($"Negatives not allowed: {negatives}");
            }
        }
    }
}
