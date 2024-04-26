using System;
namespace Program;

public class NumWordDollarizer
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a number to convert to dollars:");
            string number = Console.ReadLine();

            
           Console.WriteLine(NumberToDollars(number));
            

            Console.WriteLine("Press any button to exit or Press R to restart");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            if (input.KeyChar != 'r' && input.KeyChar != 'R')
            {
                break;
            }
        }
    }

    public static string NumberToDollars(string amount)
    {
        if (!decimal.TryParse(amount, out decimal number))
            return "Please enter a valid number.";

        if (number < 0)
            return "Negative number cannot be converted.";

        if (number > 999999999999999.99m || number < 0)
            return "Error: The number must be between 0 and 999,999,999,999,999.99.";

        if (number == 0)
            return "Zero dollar";

        long intPart = (long)number;
        int decimalPart = (int)((number - intPart) * 100);
        string words = NumberToWords(intPart) + " Dollar" + (intPart > 1 ? "s" : "");
        if (decimalPart > 0)
        {
            words += " and " + NumberToWords(decimalPart) + " Cent" + (decimalPart > 1 ? "s" : "");
        }
        return words;
    }

    static string NumberToWords(long number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToWords(Math.Abs(number));

        string words = "";

        string[] unitsMap = ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
        string[] tensMap = ["Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];

        Dictionary<long, string> multiplierMap = new Dictionary<long, string>
        {
            { 1000000000000, "Trillion" },
            { 1000000000, "Billion" },
            { 1000000, "Million" },
            { 1000, "Thousand" },
            { 100, "Hundred" }
        };

        foreach (var multiplier in multiplierMap)
        {
            if ((number / multiplier.Key) > 0)
            {
                words += NumberToWords(number / multiplier.Key) + " " + multiplier.Value + " ";
                number %= multiplier.Key;
            }
        }

        #region commented
        //if ((number / 1000000000000) > 0)
        //{
        //    words += NumberToWords(number / 1000000000000) + " Trillion ";
        //    number %= 1000000000000;
        //}

        //if ((number / 1000000000) > 0)
        //{
        //    words += NumberToWords(number / 1000000000) + " Billion ";
        //    number %= 1000000000;
        //}

        //if ((number / 1000000) > 0)
        //{
        //    words += NumberToWords(number / 1000000) + " Million ";
        //    number %= 1000000;
        //}

        //if ((number / 1000) > 0)
        //{
        //    words += NumberToWords(number / 1000) + " Thousand ";
        //    number %= 1000;
        //}

        //if ((number / 100) > 0)
        //{
        //    words += NumberToWords(number / 100) + " Hundred ";
        //    number %= 100;
        //}
        #endregion

        if (number > 0)
        {
            //if (words != "")
            //    words += "and ";

            if (number < 20)
            {
                words += unitsMap[number];
            }
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }
}
