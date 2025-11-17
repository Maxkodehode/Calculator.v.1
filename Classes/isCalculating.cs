using System.Collections;

public class Calculating
{
    string operation = "";
    double num1;
    double num2;
    bool hasInput;
    double result;
    
    public double ProcessInput(string input, double previousResult = 0.0)
    { 
        if (input != null && input.ToLower() == "clear")
        {
            return -000.00;
        }
        else if (input != null && input.ToLower() == "exit")
        {
            return -000.01;
        }
        
        string? resultString = previousResult.ToString();
        input = resultString + input!.Trim();
        
        // Isolate the operations so it can split the string into array
        string spacedInput = input
        .Replace("*", " * ")
        .Replace("/", " / ")
        .Replace("+", " + ")
        .Replace("-", " - ");

        
        string[] parts = spacedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        // Check length of array and confirm operator and digits index in array
        if (parts.Length == 3)
        {
            operation = parts[1];
            bool isNum1 = double.TryParse(parts[0], out num1);
            bool isNum2 = double.TryParse(parts[2], out num2);
            
            if (isNum1 && isNum2)
            {
                hasInput = true;
            }
            
            if (hasInput)
            {
                switch (operation)
                {
                    case "+":
                        Addition addition = new Addition();
                        result = addition.Add(num1, num2);
                        break;
                    case "-":
                        Subtraction subtraction = new Subtraction();
                        result = subtraction.Sub(num1, num2);
                        break;
                    case "*":
                        Multiplication multiplication = new Multiplication();
                        result = multiplication.Mult(num1, num2);
                        break;
                    case "/":
                        Division division = new Division();
                        result = division.Div(num1, num2);
                        break;
                    default:
                        return -111.11;
                }
                return result;
            }
            else
            {
                return -222.22;
            }
        }
        return -333.33;
    }
}