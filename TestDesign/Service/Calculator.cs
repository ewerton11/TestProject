namespace TestProject.Service;

public class Calculator : ICalculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public double CalculateAverage(params double[] value)
    {
        if (value.Length == 0)
        {
            throw new ArgumentException("A lista de valores não pode estar vazia.");
        }

        return value.Sum() / value.Length;
    }

    public double CalculateMedian(params double[] value)
    {
        if (value.Length == 0)
        {
            throw new ArgumentException("A lista de valores não pode estar vazia.");
        }

        var valuesOrdered = value.OrderBy(x => x).ToArray();
        int quite = valuesOrdered.Length / 2;

        if (valuesOrdered.Length % 2 == 0)
        {
            return (valuesOrdered[quite - 1] + valuesOrdered[quite]) / 2.0;
        }
        else
        {
            return valuesOrdered[quite];
        }
    }
}
