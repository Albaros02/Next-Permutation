class Tester
{
    public List<short[]> errors = new List<short[]>();
    public Tester(int maxLength, int caseCount, int? seed)
    {
        // This tester is using a brute force approach to 
        // check the correctness of the given solution but 
        // is not gonna handle arrays with a length larger 
        // than 15, as we know the backtrack of building the 
        // permutations grows exponentially.  
        
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
        Solution solution = new Solution(array);
        return CompareArrays(array,brute.Next , solution.Next);
    }

    private bool CompareArrays(short[] array, short[] array1 ,short[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if(array1[i] != array2[i])
            {
                array.Show();
                array1.Show();
                array2.Show();
                return false;
            }
        }
        return true;
    }
}