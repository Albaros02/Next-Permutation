namespace NextPermutationService.Common.Interfaces;

public interface IPermutationEnumerable<T>
{
    public IEnumerable<T> Next(IEnumerable<T> current);   
}