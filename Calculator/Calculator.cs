using System;

namespace Calculator
{
    public class Calculator
    {
        public void Sum(double x, double y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public void Sub(double x, double y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public void Divisor(double x, double y)
        {
            // Regra de negocio hipotetica: Pode ser aceito apenas divisao de um valor maior ou igual do que o numero que divide
            if (y > x)
            {
                var auxiliar = y;
                y = x;
                x = auxiliar;
            }

            Console.WriteLine($"{x} / {y} = {x / y}");
        }

        public void Times(double x, double y)
        {
            Console.WriteLine($"{x} x {y} = {x * y}");
        }
    }
}