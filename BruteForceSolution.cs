class BruteForceSolution
{
    private List<short[]> Candidates;
    public short[] Next { get; private set; }
    public BruteForceSolution(short[] array)
    {
        //This naive solution wont give good performance for long test cases.
        //First we iterate for every single permutation
        //and we keep the ones that are lexicographically greater.
        this.Candidates = new List<short[]>();
        foreach (var item in array.Permutations())
        {
            if(array.LexCompare(item) > 0)
            {
                this.Candidates.Add(item);
            }
        }

        // Ok now we have to decide which one is the minimum of those
        // and in order to make it a fully trusted outcome lets just
        // naively iterate over all of them and get the one we want.
        
        this.Next = (Candidates.Count > 0)? getMinimum() : array.Reverse().ToArray();
    }
    private short[] getMinimum()
    {
        short[] result = Candidates.First();
        foreach (var item in this.Candidates)
        {
            if(result.LexCompare(item) < 0)
            {
                result = item;
            }
        }
        return result;
    }
}