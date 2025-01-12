using StringCalculation.App;

try
{
    Console.WriteLine("Enter a string of numbers please.");
    var input = "//;\n2;4;6;8";

    //test the StringCalculator Add method with a string of numbers
    var result = new StringCalculator().Add(input);

    Console.WriteLine($"The sum of the string is: {result}");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Error information: {ex.Message}");
}