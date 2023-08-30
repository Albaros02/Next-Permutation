using Microsoft.AspNetCore.Mvc;
using NextPermutationService.Validation;
using NextPermutationService.Common.Interfaces;
namespace NextPermutationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermutationsController : ControllerBase
{

    private readonly IPermutationEnumerable<short> solution;

    public PermutationsController(IPermutationEnumerable<short> Solution)
    {
        solution = Solution;
    }
    
    [HttpPost]
    [Route("Next")]
    public IActionResult Next(string input)
    {
        // Lets pass the data using a regular string of numbers separated by
        // comas.
        PermutationInputValidation validator = new PermutationInputValidation(input);
        if(validator.IsValid)
        {
            return Ok(solution.Next(validator.CleanedInput));  
        }
        return BadRequest(validator.errors);
    }
    [HttpGet]
    [Route("All")]

    public string getAll()
    {
        return "all";
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
