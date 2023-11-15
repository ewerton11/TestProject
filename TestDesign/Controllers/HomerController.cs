using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers;

public class HomerController : ControllerBase
{

    private readonly ICalculator _calculator;

    public HomerController(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public IActionResult Index(int a, int b)
    {
        int result = _calculator.Add(a, b);

        return Content($"Resultado da soma: {result}");
    }

    public int Subtract(int a, int b)
    {
        return _calculator.Subtract(a, b);
    }
}
