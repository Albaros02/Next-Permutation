namespace NextPermutationService.Validation;
class PermutationInputValidation
{
    // We could use Fluent for validations but I think
    // that it would be too much for the simple verifications
    // that we should do.
    public bool IsValid => (this.errors.Count == 0);
    public List<string> errors { get; set; }
    public List<short> CleanedInput { get; set; }
    public PermutationInputValidation(string input)
    {
        errors = new List<string>();
        CleanedInput = new List<short>();
        var temp = cleanInput(input);
        foreach (var item in temp)
        {
            isAllowedNumber(item);
        }
        if(this.IsValid)
        {
            foreach (var number in temp)
            {
                CleanedInput.Add(Int16.Parse(number));
            }
        }
    }
    private string[] cleanInput(string input)
    {
        return input.Split(", ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);    
    }

    private bool isAllowedNumber(string inputNumber)
    {
        try
        {
            short s = Int16.Parse(inputNumber);
            if( s < 0 || s > 100 )
            {
                errors.Add("The input is out of bounds.");
                return false;
            }
        }
        catch
        {
            errors.Add("The input is not a number.");
            return false;
        }
        return true;
    }
}