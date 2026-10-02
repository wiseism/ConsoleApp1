using ConsoleApp1;

Greeter greeter = new();
Console.WriteLine(greeter.Greet("World"));
Console.WriteLine(string.Join(", ", greeter.GreetAll(new[] { "Ada", "  ", "Linus" })));

Calculator calculator = new();
Console.WriteLine($"1 + 2 = {calculator.Add(1, 2)}");

double[] values = { 0.1, 0.2, 0.3 };
Console.WriteLine($"sum = {calculator.Sum(values)} (close to 0.6: {Calculator.IsCloseTo(calculator.Sum(values), 0.6)})");
