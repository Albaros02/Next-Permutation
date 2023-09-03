using NextPermutationService.Tester;
using NextPermutationService.App;
using NextPermutationService.Common.Interfaces;
static class Program 
{
    static void Main()
    {
        // This tester is spouse to be use against any solution 
        // that implements IPermutationEnumerable interface.
        MyTester test1 = new MyTester(new SillySolution(),3,10,null);

        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("End of random solution.");

        MyTester test2 = new MyTester(new PermutationSolution(),3,10,null);
    }
}

class SillySolution : IPermutationEnumerable<short>
{
    public IEnumerable<short> Next(IEnumerable<short> current)
    {
        Random r = new Random();
        List<short> result = new List<short>();
        for (int i = 0; i < current.Count(); i++)
        {
            result.Add((short)(r.Next(0,100)));
        }
        return result;
    }   
}