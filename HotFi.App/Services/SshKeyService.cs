using System.Threading.Tasks;
using HotFi.App.Enums;

namespace HotFi.App.Services
{
    public class SshKeyService : IKeyService
    {
        public async Task CreateKeys(KeyTypes keyType)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetKey(string name, KeyCategory keyCategory, KeyTypes keyType)
        {
            throw new System.NotImplementedException();
        }
    }
}