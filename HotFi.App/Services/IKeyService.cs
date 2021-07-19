using System.Threading.Tasks;
using HotFi.App.Enums;

namespace HotFi.App.Services
{
    public interface IKeyService
    {
        Task CreateKeys(KeyTypes keyType);
        Task<string> GetKey(string name, KeyCategory keyCategory, KeyTypes keyType);
    }
}