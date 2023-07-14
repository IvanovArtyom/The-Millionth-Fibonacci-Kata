using BigInt = System.Numerics.BigInteger;

public class Fibonacci
{
    public static void Main()
    {
        // Test
        var t = fib(20);
        // ...should return 6765
    }

    public static BigInt fib(BigInt n)
    {
        if (n == 0)
            return 0;

        BigInt _, fibonacci = MatrixPower(1, 1, 1, 0, BigInt.Abs(n) - 1, out _, out _, out _);

        return n < 0 && n.IsEven ? -fibonacci : fibonacci;
    }

    public static BigInt MatrixPower(BigInt a11, BigInt a12, BigInt a21, BigInt a22, BigInt n, out BigInt b12, out BigInt b21, out BigInt b22)
    {
        if (n == 0)
        {
            b12 = b21 = 0;

            return b22 = 1;
        }

        BigInt c12, c21, c22, c11 = MatrixPower(a11, a12, a21, a22, n.IsEven ? n / 2 : n - 1, out c12, out c21, out c22);

        if (n.IsEven)
        {
            a11 = c11; a12 = c12; 
            a21 = c21; a22 = c22;
        }

        b12 = c11 * a12 + c12 * a22;
        b21 = c21 * a11 + c22 * a21;
        b22 = c21 * a12 + c22 * a22;

        return c11 * a11 + c12 * a21;
    }
}