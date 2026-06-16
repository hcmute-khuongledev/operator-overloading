namespace OperatorOverloading.Vector2D
{
    public class Vector2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2D() : this(0, 0) { }
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DoDai => Math.Sqrt(X * X + Y * Y);

        public static Vector2D operator +(Vector2D a, Vector2D b)
            => new Vector2D(a.X + b.X, a.Y + b.Y);

        public static Vector2D operator -(Vector2D a, Vector2D b)
            => new Vector2D(a.X - b.X, a.Y - b.Y);

        public static Vector2D operator -(Vector2D v)
            => new Vector2D(-v.X, -v.Y);

        public static Vector2D operator *(Vector2D v, double k)
            => new Vector2D(v.X * k, v.Y * k);

        public static Vector2D operator *(double k, Vector2D v)
            => v * k;

        public static double operator *(Vector2D a, Vector2D b)
            => a.X * b.X + a.Y * b.Y;

        public static bool operator ==(Vector2D? a, Vector2D? b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector2D? a, Vector2D? b)
            => !(a == b);

        public override bool Equals(object? obj)
            => obj is Vector2D other && this == other;

        public override int GetHashCode()
            => HashCode.Combine(X, Y);

        public static implicit operator Vector2D((double x, double y) tuple)
            => new Vector2D(tuple.x, tuple.y);

        public override string ToString()
            => $"({X:F2}, {Y:F2})";
        
    }
}