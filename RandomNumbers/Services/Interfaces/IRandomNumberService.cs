namespace RandomNumbers.Services.Interfaces
{
    public interface IRandomNumberService
    {
        public int Generate(int min, int max);
    }
}