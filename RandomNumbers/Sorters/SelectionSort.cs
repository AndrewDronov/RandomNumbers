namespace RandomNumbers.Sorters
{
    public class SelectionSort : ISort
    {
        public void Sort(int[] array)
        {
            var n = array.Length;
            for (var i = 0; i < n - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                (array[min], array[i]) = (array[i], array[min]);
            }
        }
    }
}