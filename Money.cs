namespace OperatorOverloading.Money
{
    public class Money
        {
            public decimal Amount   { get; private set; }
            public string  Currency { get; private set; }

            public Money(decimal amount, string currency)
            {
                if (amount < 0)
                    throw new ArgumentException("So tien khong the am!");
                Amount   = amount;
                Currency = currency.ToUpper();
            }

            private static void KiemTraCungDonVi(Money a, Money b)
            {
                if (a.Currency != b.Currency)
                    throw new InvalidOperationException(
                        $"Khong the thuc hien phep toan giua {a.Currency} va {b.Currency}. " +
                        $"Vui long quy doi ve cung don vi truoc.");
            }

            public static Money operator +(Money a, Money b)
            {
                KiemTraCungDonVi(a, b);
                return new Money(a.Amount + b.Amount, a.Currency);
            }

            public static Money operator -(Money a, Money b)
            {
                KiemTraCungDonVi(a, b);
                if (a.Amount < b.Amount)
                    throw new InvalidOperationException("Ket qua tru khong duoc am!");
                return new Money(a.Amount - b.Amount, a.Currency);
            }

            public static Money operator *(Money m, decimal heSo)
            {
                if (heSo < 0)
                    throw new ArgumentException("He so khong the am!");
                return new Money(m.Amount * heSo, m.Currency);
            }

            public static Money operator *(decimal heSo, Money m) => m * heSo;

            public static bool operator >(Money a, Money b)
            {
                KiemTraCungDonVi(a, b);
                return a.Amount > b.Amount;
            }

            public static bool operator <(Money a, Money b)
            {
                KiemTraCungDonVi(a, b);
                return a.Amount < b.Amount;
            }

            public static bool operator ==(Money a, Money b)
            {
                if (a is null && b is null) return true;
                if (a is null || b is null) return false;
                return a.Currency == b.Currency && a.Amount == b.Amount;
            }

            public static bool operator !=(Money a, Money b) => !(a == b);

            public override bool Equals(object obj) => this == (obj as Money);
            public override int  GetHashCode()      => HashCode.Combine(Amount, Currency);

            public static Money operator /(Money m, int soNguoi)
            {
                if (soNguoi <= 0)
                    throw new ArgumentException("So nguoi phai lon hon 0!");
                return new Money(Math.Round(m.Amount / soNguoi, 0), m.Currency);
            }

            public static Money QuyDoi(Money nguon, string donViDich, decimal tyGia)
            {
                if (tyGia <= 0)
                    throw new ArgumentException("Ty gia phai duong!");
                return new Money(Math.Round(nguon.Amount * tyGia, 0), donViDich);
            }

            public override string ToString() => $"{Amount:N0} {Currency}";
        }
}