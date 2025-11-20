



Psudocode:
check if input = null

split string into array

check which operator is used using array[1]

Assign array[0] and array[2] to num1 and num2 variable pass it to the calculation class acording to the operator in the array.

display result (maybe using Spectral.Console)


Expansion:

return previous result an asign in to num1 for continous calculations in a while loop.

using List to calculate a string with more than 1 operand.

![alt text](image.png)




LLM README Text:

# Console Calculator Project

This project is a basic console application written in C# designed to perform arithmetic calculations. Its primary goal is to demonstrate **method overloading** and structured **program flow** based on user input.

## 🔑 Key Features

* **Method Overloading:** The core operations (`Add`, `Sub`, `Mult`, `Div`) use overloaded methods. Each operation class includes a method that accepts two numbers and another that accepts a list of numbers.
* **Sequential Calculation:** The calculator allows you to continue operations using the previous result (e.g., after calculating `5`, typing `+10` calculates `15`).
* **Expression Handling:** The program can process expressions containing multiple operators (e.g., `10 + 5 * 2`).
* **Basic Order of Operations:** Multiplication and Division are solved before Addition and Subtraction in complex expressions.
* **Commands:** Supports `exit` to close the application and `clear` to reset the current calculation.

## 🚀 How to Run

1.  **Prerequisites:** Ensure you have the .NET SDK installed.
2.  **Run:** Compile and execute the program from the project directory:

    ```bash
    dotnet run
    ```

## 🖥️ Usage

Enter your full expression, or use the continuation feature once a result is displayed.

| Input | Description | Example |
| :--- | :--- | :--- |
| **New Expression** | Enter a full calculation. | `20 / 4 - 1` |
| **Continuation** | Use the previous result for the next step. | *If result is 15:* Type `*3` |
| **Command** | Use control commands. | `exit` or `clear` |

## ⚙️ Project Structure

The code is organized into separate files to model the required components:

| File | Purpose |
| :--- | :--- |
| `Program.cs` | Manages the main application loop and user input display. |
| `Calculate.cs` | Handles input parsing, command checks, error routing, and determines if a simple or complex calculation is needed. |
| `CalculatingList.cs` | Contains the logic for processing expressions with multiple operators, ensuring the correct order of operations. |
| `Addition.cs`, `Subtraction.cs`, etc. | Separate classes that house the overloaded calculation methods. |

