# Text to Number Transformer Console App

This is a simple C# console application built using .NET SDK version 9.0.104. The app processes a given word and transforms it through several stages of numerical and character-based logic.

## Features

- Converts characters to numerical representations based on custom mappings.
- Alternating addition and subtraction to calculate a transformation value.
- Generates number sequences that sum to a target value.
- Converts those sequences back into characters.
- Performs a final transformation on the generated characters and displays the result.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Ubuntu 22.04 or compatible OS
- A terminal/command-line interface

## Installation

1. Make sure you have .NET SDK installed:
   ```bash
   dotnet --version

2. Clone this repository:
    ```bash
    git clone https://github.com/nalen-dev/cs-consoleapp
    cd ./MyConsoleApp

3. Run the application
    ```bash
    dotnet run

You will be prompted to enter a word. The program will display step-by-step results for each processing phase, including:
- Number format conversion
- Calculation result
- Sequence generation
- Character transformation
- Final result with a minor twist
