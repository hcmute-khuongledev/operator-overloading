using FractionApp;

class Program
{
    static void Main()
    {
        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(2, 4);
        Fraction f3 = new Fraction(1, 3);

        Console.WriteLine($"f1: {f1}");
        Console.WriteLine($"f2: {f2}");
        Console.WriteLine($"f3: {f3}");

        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($"{f1} / {f2} = {f1 / f2}");

        Console.WriteLine($"Compare f1 == f2: {f1 == f2}");
        Console.WriteLine($"Compare f1 != f3: {f1 != f3}");
        Console.WriteLine($"Compare f1 > f3: {f1 > f3}");
        Console.WriteLine($"Compare f3 < f1: {f3 < f1}");

        Console.WriteLine($"{f1} + 2 = {f1 + 2}");
        Console.WriteLine($"3 + {f1} = {3 + f1}");
    }
}