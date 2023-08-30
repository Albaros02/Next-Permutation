using NextPermutationService.App;
using NextPermutationService.Common.Interfaces;
namespace NextPermutationService.Tester;
class MyTester
{
    public List<short[]> errors = new List<short[]>();
    private readonly IPermutationEnumerable<short> solution;
    public MyTester(IPermutationEnumerable<short> Solution,int maxLength, int caseCount, int? seed)
    {
        // This tester is using a brute force approach to 
        // check the correctness of the given solution but 
        // is not gonna handle arrays with a length larger 
        // than 15, as we know the backtrack of building the 
        // permutations grows at a factorial rate.  
        
        solution = Solution;
        Random rand = new Random();
        
        for (int i = 0; i < caseCount; i++)
        {
            int temp = rand.Next(maxLength);
            short[] testArray = new short[temp];
            for (int j = 0; j < temp; j++)
            {
                testArray[j] = ((short)rand.Next(0,100));
            }
            if(Test(testArray))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine("Ok");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine("Fail");
                errors.Add(testArray);
            }
        }
    }
    private bool Test(short[] array)
    {
        BruteForceSolution brute = new BruteForceSolution(array);
        return CompareArrays(array,brute.Next , solution.Next(array).ToArray());
    }

    private bool CompareArrays(short[] array, short[] array1 ,short[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if(array1[i] != array2[i])
            {
                return false;
            }
        }
        return true;
    }
}