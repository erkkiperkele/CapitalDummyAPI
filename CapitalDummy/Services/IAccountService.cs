using CapitalDummy.Models;
using CapitalDummy.ResponseModels;
using System.Threading.Tasks;

namespace CapitalDummy.Services
{
    public interface IAccountService
    {
        Task<AuthorizationResponse> Authorize(AccountCredentials credentials);
        Task<AuthorizedResponse> AnswerSecurityQuestion(AccountCredentials credentials, AuthorizationResponse previousAuthorizationResponse);
        Task<AccountsDetailsResponse> GetAccountDetails(AuthorizedResponse loginInfo);
    }
}
