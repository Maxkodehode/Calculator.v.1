using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            bool hasInput = false;
            
            Console.WriteLine("Enter your number an operations to calculate. e.g. 5+5.");
            string? input = Console.ReadLine();
            Calculating calculate = new Calculating();
            
            if (input == null)
            {
                Console.WriteLine("No valid input detected");
            }
            else
            {
                result = calculate.ProcessInput(input);
                Console.WriteLine(result);
                hasInput = true;
            }
            
            Console.WriteLine("To continue calculating, you only need to input the operation followed by the value.\nExample: If the previous result was 5, typing +10 will calculate 5+10.");
            
            while (hasInput)
            {
                if (input != null && input.ToLower() == "exit")
                {
                    hasInput = false;
                    continue;
                }
                else
                {
                    Console.Write("> ");
                    input = Console.ReadLine();
                    
                    if (input == null)
                    {
                        Console.WriteLine("No valid input detected");
                    }
                    else
                    {
                        double previousResult = result;
                        result = calculate.ProcessInput(input, previousResult);
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}