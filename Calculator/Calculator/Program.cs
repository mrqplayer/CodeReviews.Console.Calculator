using CalculatorLibrary;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            bool endApp = false;


            while (!endApp)
            {
                Console.WriteLine("Console Calculator in C#\r");
                Console.WriteLine($"Usage Count: {calculator.UsageCount} ");
                Console.WriteLine("------------------------\n");


                double cleanNum1 = 0;
                double cleanNum2 = 0;
                double result = 0;

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tr - Square Root");
                Console.WriteLine("\tp - Power");
                Console.WriteLine("\te - 10^x");
                Console.WriteLine("\tsin - Sin");
                Console.WriteLine("\tcos - Cos");
                Console.WriteLine("\ttan - Tan");
                Console.WriteLine("\th - Show history");
                Console.WriteLine("\tc - Clear history");
                Console.WriteLine("\tu - Use result from history");
                Console.Write("Your option? ");

                string op = Console.ReadLine()?.ToLower() ?? "";

                List<string> validOps = new()
                {
                 "a","s","m","d","r","p","e",
                 "sin","cos","tan",
                 "h","c","u"
                };

                if (!validOps.Contains(op))
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                if (op == "h")
                {
                    for (int i = 0; i < calculator.History.Count; i++)
                    {
                        var c = calculator.History[i];
                        var h = calculator.History[i];

                        Console.WriteLine($"{i}: {h.Num1} {h.Operation} {h.Num2} = {h.Result}"); ;
                    }
                    continue;
                }
                
                if (op == "c")
                {
                    calculator.ClearHistory();
                    Console.WriteLine("History cleared!");
                    continue;
                }

                if (op == "u")
                {
                    if (calculator.History.Count == 0)
                    {
                        Console.WriteLine("No history available.");
                        continue;
                    }

                    Console.WriteLine("Choose result index:");
                    for (int i = 0; i < calculator.History.Count; i++)
                    {
                        Console.WriteLine($"{i}: {calculator.History[i].Result}");
                    }

                    int index;
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.Write("Invalid index: ");
                    }
                    double reused = calculator.History[index].Result;

                    Console.Write("Type second number: ");
                    while (!double.TryParse(Console.ReadLine(), out cleanNum2))
                    {
                        Console.Write("Invalid number: ");
                    }
                    Console.Write("Choose operation (a/s/m/d/p): ");
                    string? op2 = Console.ReadLine()?.ToLower();

                    if (op2 == null)
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }
                    result = calculator.DoOperation(reused, cleanNum2, op2);

                    Console.WriteLine($"Result: {result}");
                    continue;
                }


                if (op != "h" && op != "c" && op != "u")
                {
                    Console.Write("Type a number: ");
                    while (!double.TryParse(Console.ReadLine(), out cleanNum1))
                    {
                        Console.Write("Invalid input: ");
                    }

                    if (op != "r" && op != "sin" && op != "cos" && op != "tan" && op != "e")
                    {
                        Console.Write("Type another number: ");

                        while (!double.TryParse(Console.ReadLine(), out cleanNum2))
                        {
                            Console.Write("Invalid input: ");
                        }
                    }

                    try
                    {
                        result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("Math error.\n");
                        }
                        else
                        {
                            Console.WriteLine($"Your result: {result}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                }


                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }
                else
                {
                    Console.Clear();
                }
            }
            calculator.Finish();
            return;
        }
    }
}