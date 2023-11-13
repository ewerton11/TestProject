namespace TestProject;
public interface ICalculator
{
    int Add(int a, int b);
    int Subtract(int a, int b);
    int Multiply(int a, int b);
    double CalculateAverage(params double[] value);
    double CalculateMedian(params double[] value);
}
