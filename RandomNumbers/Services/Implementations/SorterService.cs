using RandomNumbers.Services.Interfaces;
using RandomNumbers.Sorters;
using System.Collections.Generic;

namespace RandomNumbers.Services.Implementations
{
    public class SorterService : ISorterService
    {
        private readonly List<ISort> _sorters = new() { new SelectionSort(), new BubbleSort() };
        private readonly IRandomNumberService _randomNumberService;

        public SorterService(IRandomNumberService randomNumberService)
        {
            _randomNumberService = randomNumberService;
        }

        public void Sort(int[] array)
        {
            var sorter = _sorters[_randomNumberService.Generate(0, _sorters.Count - 1)];

            sorter.Sort(array);
        }
    }
}