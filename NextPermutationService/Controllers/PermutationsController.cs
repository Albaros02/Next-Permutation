using Microsoft.AspNetCore.Mvc;
using NextPermutationService.Validation;
using NextPermutationService.Common.Interfaces;
using NextPermutationService.Extensions;
namespace NextPermutationService.Controllers;

[ApiController]
[Route("[controller]")]
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
            return Ok(solution.Next(validator.CleanedInput).ToStringWithComas());  
        }
        return BadRequest(validator.errors);
    }
}
