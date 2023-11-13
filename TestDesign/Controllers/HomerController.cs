using Microsoft.AspNetCore.Mvc;
using TestProject.Service;

namespace TestProject.Controllers;

public class HomerController : ControllerBase
{

    private readonly ICalculator _calculator;

    public HomerController(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public IActionResult Index()
    {
        int result = _calculator.Add(3, 5);

        return Content($"Resultado da soma: {result}");
    }
}
