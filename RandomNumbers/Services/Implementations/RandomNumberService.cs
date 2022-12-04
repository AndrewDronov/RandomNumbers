using RandomNumbers.Services.Interfaces;
using System;

namespace RandomNumbers.Services.Implementations
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly Random _random = new();

        public int Generate(int min, int max)
        {
            return _random.Next(min, max + 1);
        }
    }
}