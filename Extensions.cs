static class Extensions
{
    public static void Show(this short[] array)
    {
        foreach (var item in array)
        {
            System.Console.Write(item+" ");
        }
        System.Console.WriteLine();
    }
    public static short LexCompare(this short[] array, short[] input)
    {
        for (short i = 0; i < array.Length; i++)
        { 
            if(array[i]<input[i])
            {
                return (short)(i+1);
            }else 
            if(array[i]>input[i])
            {
                return -1;
            }
        }
        return 0;
    }
    public static IEnumerable<short[]> Permutations(this short[] array)
    {
        foreach (var item in permutations(new short[array.Length], 0, new bool[array.Length]))
        {
            short[] result = new short[item.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[item[i]];
            }
            yield return result;
        }
    }

    private static IEnumerable<short[]> permutations(short[] array, int position, bool[] used)
    {
        if (position >= array.Length)
            yield return array;
        for (short i = 0; i < array.Length; i++)
        {
            if (used[i] is false)
            {
                array[position] = i;
                used[i] = true;
                foreach (var item in permutations(array, position + 1, used))
                {
                    yield return item;
                }
                used[i] = false;
            }
        }
    }
}
