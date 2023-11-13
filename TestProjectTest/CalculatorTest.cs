using Microsoft.AspNetCore.Mvc;
using Moq;
using TestProject;
using TestProject.Controllers;
using TestProject.Service;

namespace TestProjectTest;

public class CalculatorTest
{
    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        var calculatorMock = new Mock<ICalculator>();
        calculatorMock.Setup(c => c.Add(3, 5)).Returns(8);

        var controller = new HomerController(calculatorMock.Object);

        // Act
        IActionResult result = controller.Index();

        // Assert
        var contentResult = Assert.IsType<ContentResult>(result);  // Verificar o tipo do resultado
        Assert.Equal("Resultado da soma: 8", contentResult.Content);
    }

    [Fact]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.Subtract(8, 3);

        // Assert
        Assert.Equal(5, result);
    }

    [Theory]
    [InlineData(2, 3, 6)]    // Teste com dados de entrada 2 e 3, esperando 6 como resultado
    [InlineData(-1, 2, -2)]   // Teste com dados de entrada -1 e 2, esperando -2 como resultado
    [InlineData(0, 5, 0)]     // Teste com dados de entrada 0 e 5, esperando 0 como resultado
    [InlineData(-4, -2, 8)]   // Teste com dados de entrada -4 e -2, esperando 8 como resultado
    public void DeveMultiplicarDoisNumeros(int a, int b, int expectedOutcome)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expectedOutcome, result);
    }

    [Theory]
    [InlineData(new double[] { 1, 2, 3, 4, 5 }, 3)]   // Teste com média de 1, 2, 3, 4, 5, esperando 3
    [InlineData(new double[] { -1, 0, 1 }, 0)]   // Teste com média de -1, 0, 1, esperando 0
    [InlineData(new double[] { 2.5, 3.5, 4.5 }, 3.5)]   // Teste com média de 2.5, 3.5, 4.5, esperando 3.5
    public void MustCalculateAverage(double[] value, double expectedOutcome)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        double result = calculator.CalculateAverage(value);

        // Assert
        Assert.Equal(expectedOutcome, result, precision: 6);
    }

    [Theory]
    [InlineData(new double[] { 1, 2, 3, 4, 5 }, 3)]   // Teste com mediana de 1, 2, 3, 4, 5, esperando 3
    [InlineData(new double[] { -1, 0, 1 }, 0)]   // Teste com mediana de -1, 0, 1, esperando 0
    [InlineData(new double[] { 2.5, 3.5, 4.5 }, 3.5)]   // Teste com mediana de 2.5, 3.5, 4.5, esperando 3.5
    [InlineData(new double[] { 1, 2, 3, 4 }, 2.5)]   // Teste com mediana de 1, 2, 3, 4, esperando 2.5
    public void MustCalculateMedian(double[] value, double expectedOutcome)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        double result = calculator.CalculateMedian(value);

        // Assert
        Assert.Equal(expectedOutcome, result, precision: 6);
    }
}