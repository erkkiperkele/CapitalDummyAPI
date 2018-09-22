using CapitalDummy.Models;
using System.Threading.Tasks;

namespace CapitalDummy
{
    public interface IAccountInformant
    {
        Task<AccountSummary> RetrieveAccountSummary(AccountCredentials credentials);
    }
}
