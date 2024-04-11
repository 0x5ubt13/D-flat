namespace Calculator;

public class Calculator<T> : IBinaryInteger<T>
{
    public T Add(T i1, T i2)
        => i1 + i2;

    public T Subtract(T i1, T i2)
        => i1 - i2;

    public T Multiply(T i1, T i2)
        => i1 * i2;
    
    public T Divide(T i1, T i2)
        => i1 / i2;
}