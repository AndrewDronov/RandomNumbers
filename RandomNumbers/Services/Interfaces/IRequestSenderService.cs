using System.Threading.Tasks;

namespace RandomNumbers.Services.Interfaces
{
    public interface IRequestSenderService
    {
        public Task<bool> SendAsync(string path, object model);
    }
}