Project Title: StringCalculator

Description: A C# .Net application that provides an Add method. The Add method takes a string of numbers from a user's input and adds the numbers together to return a final sum total number.

Usage: The application is currently set up as a .Net Console application and able to run in Visual Studio. Once the project is opened, you can set the values of the user INPUT STRING in the Program.cs file. Or you can manually enter the user input into the console window.

Functionality and validation required of the StringCalculator Add method:

The method can take a string representing numbers separated by commas, and will return their sum (for an
empty string it will return 0) for example “” or “1” or “1,2”.
1. Start with the simplest case of an empty string and move to 1 and 2 numbers.
2. Allow the Add method to handle an unknown amount of numbers.
3. Allow the Add method to handle new lines between numbers (as well as commas).
a. The following input is ok: “1\n2,3” (will equal 6).
b. The following input is NOT ok: “1,\n”.
4. Support different single character delimiters (case-insensitive).
To change a delimiter, the beginning of the string will contain a separate line that looks like this:
“//[delimiter]\n[numbers...]” for example “//;\n1;2” should return three where the delimiter is ‘;’.
5. Calling Add with a negative number will throw an exception “Negatives not allowed” - and the negative
that was passed in. If there are multiple negatives, show all of them in the exception message.
6. Numbers greater than 1000 should be ignored, so adding 2 + 1001 + 13 = 15.
7. Allow multiple delimiters like this: “//[delim1][delim2]\n” for example “//*%\n1*2%3” should return 6.
