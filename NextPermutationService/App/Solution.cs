using NextPermutationService.Common.Interfaces;
namespace NextPermutationService.App;
class Solution : IPermutationEnumerable<short>
{
    public short[] current { get; set;}
    public IEnumerable<short> Next(IEnumerable<short> input)
    {
        this.current = getNext(input.ToArray());
        return current;
    } 
    public Solution()
    {
        current = new short[0];
    }
    private short[] getNext(short[] array)
    {
        for (int i = array.Length - 2; i >= 0 ; i--)
        {
            short minGreater = short.MaxValue;
            int index = -1;
            for (int j = i; j < array.Length; j++)
            {
                if (array[j]> array[i] && array[j]< minGreater)
                {
                    index = j;
                    minGreater = array[j];
                }    
            }

            if ( index != -1)
            {
                // we found the place to make the change 
                // Lets swap...
                short temp = array[index];
                array[index] = array[i];
                array[i] = temp;

                LowCostOrder(ref array, i+1);
                return array;
            }
        }

        // in case we did not find the place to make the change 
        // then we return the reverse of the current array. 
        return array.Reverse().ToArray();
    }

    private void LowCostOrder(ref short[] array , int startPosition)
    {
        short[] sortedArrayStructure = new short[110]; 
        for (int i = startPosition; i < array.Length; i++)
        {
            sortedArrayStructure[array[i]]++;
        }
        int position = startPosition;
        for (short i = 0; i < 110; i++)
        {
            while(sortedArrayStructure[i] > 0)
            {
                array[position] = i;
                sortedArrayStructure[i]--;
                position++;
            }
        }
    }

}