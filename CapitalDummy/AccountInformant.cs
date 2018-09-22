using CapitalDummy.Models;
using CapitalDummy.ResponseModels;
using CapitalDummy.Services;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalDummy
{
    public class AccountInformant : IAccountInformant
    {
        private readonly IAccountService accountService;

        public AccountInformant(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<AccountSummary> RetrieveAccountSummary(AccountCredentials credentials)
        {
            var authorizationResponse = await accountService.Authorize(credentials);
            var loginInfo = await accountService.AnswerSecurityQuestion(credentials, authorizationResponse);
            var accountDetails = await accountService.GetAccountDetails(loginInfo);

            var operationsAccounts = accountDetails.Accounts
                .Where(x => x.Category == Catergory.Operations)
                .Select(ToSummary)
                .ToList();

            var usAccountsBalances = accountDetails.Accounts
                .Where(x => x.Currency == Currency.USD)
                .Select(ToUsSummary)
                .ToList();

            var holder = accountDetails.Accounts
                .First()
                .Holder;

            var biggestCreditTrx = accountDetails.Accounts
                .SelectMany(x => x.Transactions)
                .OrderByDescending(x => x.Credit)
                .First();

            var accountSummary = new AccountSummary
            {
                LoginId = accountDetails.Login.Id,
                BiggestCreditTrxId = biggestCreditTrx.Id,
                Holder = new UserSummary { Email = holder.Email, Name = holder.Name },
                OperationAccounts = operationsAccounts,
                RequestId = accountDetails.RequestId,
                USDAccounts = usAccountsBalances
            };

            return accountSummary;
        }

        private OperationSummary ToSummary(AccountDetails details)
        {
            return new OperationSummary
            {
                AccountNumber = details.AccountNumber,
            };
        }

        private USDAccountSummary ToUsSummary(AccountDetails details)
        {
            return new USDAccountSummary
            {
                Balance = details.Balance.Current,
            };
        }
    }
}
