using OperatorOverloading.Money;
using OperatorOverloading.Fraction;
using OperatorOverloading.Vector2D;

class Program
{
    static void Main()
    {
        // TestVector2D();
        TestMoney();
    }

    private static void TestMoney()
    {
        Money luong = new Money(15_000_000, "VND");
        Money thuong = new Money(3_000_000, "VND");
        Money lamThemGio = luong * 1.5m;

        Console.WriteLine($"Luong co ban: {luong}");
        Console.WriteLine($"Thuong thang: {thuong}");
        Console.WriteLine($"Luong lam them: {lamThemGio}");
        Console.WriteLine($"Tong thu nhap: {luong + thuong}");
        Console.WriteLine($"Chi tieu: {luong - thuong}");
        Console.WriteLine($"Luong > Thuong: {luong > thuong}");
        Console.WriteLine($"Luong < Thuong: {luong < thuong}");

        Console.WriteLine("\n--- Bep logic: khac don vi ---");
        try
        {
            Money usd = new Money(100, "USD");
            Money tong = luong + usd;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }

        Console.WriteLine("\n=== PHAN NANG CAO ===");

        Money usd100 = new Money(100, "USD");
        Money vnd100 = new Money(100, "VND");

        Money usdSangVnd = Money.QuyDoi(usd100, "VND", 25_500);
        Console.WriteLine($"QuyDoi {usd100} -> {usdSangVnd}");

        Money a = new Money(100, "USD");
        Money b = new Money(100, "USD");
        Money c = new Money(200, "USD");

        Console.WriteLine($"\n{a} == {b}: {a == b}");
        Console.WriteLine($"{a} == {c}: {a == c}");
        Console.WriteLine($"{a} != {c}: {a != c}");

        Console.WriteLine($"{usd100} != {vnd100}: {usd100 != vnd100}");
        Console.WriteLine($"{usd100} == {vnd100}: {usd100 == vnd100}");

        Money tongHoaDon    = new Money(1_200_000, "VND");
        Money phanCua1Nguoi = tongHoaDon / 4;
        Console.WriteLine($"\nHoa don {tongHoaDon} chia 4 nguoi: {phanCua1Nguoi}");

        Money thuongX2 = 2.0m * thuong;
        Console.WriteLine($"He so trai: 2.0 * {thuong} = {thuongX2}");
    }

    private static void TestVector2D()
    {
        Vector2D v1 = new Vector2D(3, 4);
        Vector2D v2 = new Vector2D(1, 2);
        
        Console.WriteLine($"v1 = {v1}");             // (3.00, 4.00)
        Console.WriteLine($"v2 = {v2}");             // (1.00, 2.00)
        Console.WriteLine($"v1 + v2 = {v1 + v2}");  // (4.00, 6.00)
        Console.WriteLine($"v1 - v2 = {v1 - v2}");  // (2.00, 2.00)
        Console.WriteLine($"v1 * 2 = {v1 * 2}");   // (6.00, 8.00)
        Console.WriteLine($"3 * v2 = {3 * v2}");   // (3.00, 6.00)
        Console.WriteLine($"v1 · v2 = {v1 * v2}"); // 3*1 + 4*2 = 11
        Console.WriteLine($"-v1 = {-v1}");        // (-3.00, -4.00)
        Console.WriteLine($"|v1| = {v1.DoDai:F4}"); // 5.0000

    }

    private static void TestFraction()
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