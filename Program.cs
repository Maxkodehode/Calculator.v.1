using System;
using Spectre.Console;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // The flag is moved outside the loop to persist its state, 
            // ensuring the exit command works correctly.
            bool shouldExit = false; 

            while (true)
            { 
                // Check if inner loop told us to exit
                if (shouldExit) 
                {
                    Console.WriteLine("Exiting calculator.");
                    break; // Exits the outer loop
                }
                
                // Reset variables for a new calculation block
                double result = 0.0;
                bool hasInput = false;

                // --- Initial Input Prompt ---
                AnsiConsole.MarkupLine("[green]Enter your number an operations to calculate. e.g. 5+5. [/]");
                AnsiConsole.MarkupLine("[green]You can also type exit to 'exit' the program or 'clear' to start a new calculation[/]");
                AnsiConsole.MarkupLine("[green]---------------------------------------------------------------------------------------[/]");  
                Console.Write("> ");
                string? input = Console.ReadLine();
                Calculating calculate = new Calculating();
                
                if (input == null)
                {
                    AnsiConsole.MarkupLine("[red]No valid input detected[/]");
                }
                else
                {
                    result = calculate.ProcessInput(input);
                    
                    // Check special return codes after the first calculation
                    if (result == -000.01)
                    {
                        shouldExit = true;
                        continue; // Go to top to trigger exit check
                    }
                    else if (result == -000.00)
                    {
                        AnsiConsole.MarkupLine("[green]Starting new calculation.[/]");
                        continue; // Go to top to restart
                    }

                    AnsiConsole.MarkupLine($"[yellow]{result}[/]");
                    hasInput = true;
                }
                
                // --- Continuation Prompt ---
                AnsiConsole.MarkupLine("[green]To continue calculating, you only need to input the operation followed by the value.\nExample: If the previous result was 5, typing +10 will calculate 5+10.[/]");
                AnsiConsole.MarkupLine("[green]Example: If the previous result was 5, typing +10 will calculate 5+10.[/]");
                AnsiConsole.MarkupLine("[green]---------------------------------------------------------------------------------------[/]");  
  
                // --- Continuation Loop ---
                while (hasInput)
                {
                    Console.Write("> ");
                    input = Console.ReadLine();
                    
                    if (input == null)
                    {
                        AnsiConsole.MarkupLine("[red]No valid input detected[/]");
                    }
                    else
                    {
                        double previousResult = result;
                        result = calculate.ProcessInput(input, previousResult);
                        
                        // Check special return codes inside the inner loop
                        if (result == -000.01)
                        {
                            shouldExit = true;
                            break; // Breaks inner loop, returns to outer loop check
                        }
                        else if (result == -000.00)
                        {
                            AnsiConsole.MarkupLine("[blue]Starting new calculation.[/]");
                            break; // Breaks inner loop, outer loop restarts
                        }
                        
                        AnsiConsole.MarkupLine($"[yellow]{result}[/]");
                    }
                }
            }
        }
    }
}