Console.Clear();
Console.WriteLine("Calculadora em C Sharp");

var calculator = new Calculator.Calculator();

Console.WriteLine("Write two values");

Console.Write("> ");
double firstNumber = Convert.ToDouble(Console.ReadLine());

Console.Write("> ");
double secondNumber = Convert.ToDouble(Console.ReadLine());

Console.Clear();

calculator.Sum(firstNumber, secondNumber);
calculator.Sub(firstNumber, secondNumber);
calculator.Divisor(firstNumber, secondNumber);
calculator.Times(firstNumber, secondNumber);