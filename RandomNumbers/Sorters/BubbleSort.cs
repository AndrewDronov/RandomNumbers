namespace RandomNumbers.Sorters
{
    public class BubbleSort : ISort
    {
        public void Sort(int[] array)
        {
            var n = array.Length;
            
            for (var i = 0; i < n - 1; i++)
            for (var j = 0; j < n - i - 1; j++)
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
        }
    }
}