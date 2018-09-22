using CapitalDummy.Extensions;
using CapitalDummy.Models;
using CapitalDummy.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapitalDummy.Services
{
    public class AccountService : IAccountService
    {
        private HttpClient httpClient;

        public AccountService()
        {
            InitializeHttpClient();
        }

        public async Task<AuthorizationResponse> Authorize(AccountCredentials credentials)
        {
            var jsonContent = JsonConvert.SerializeObject(new
            {
                Institution = credentials.Institution,
                Username = credentials.Username,
                Password = credentials.Password,
                Save = true,
                MostRecentCached = false,
                Tag = "FlAym"
            });

            var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("BankingServices/Authorize", stringContent);

            HandleHttpErrors(response);

            return await response.Content.ReadAsAsync<AuthorizationResponse>();
        }

        public async Task<AuthorizedResponse> AnswerSecurityQuestion(AccountCredentials credentials, AuthorizationResponse previousAuthorizationResponse)
        {
            // HACK: Not supported at the moment, will implement it later if needed,
            // at the moment only one question is answered at once
            var securityQuestion = previousAuthorizationResponse.SecurityChallenges.First();

            var securityResponse = credentials
                .SecurityQuestions
                .First(x => x.Question == securityQuestion.Prompt);

            var jsonContent = JsonConvert.SerializeObject(new
            {
                RequestId = previousAuthorizationResponse.RequestId,
                Institution = credentials.Institution,
                Username = credentials.Username,
                Password = credentials.Password,
                SecurityResponses = "TOREPLACE" // HACK to serialize value as propety name
            });

            var sercurityResponses = $"{{ \"{securityResponse.Question}\" : [ \"{securityResponse.Answer}\" ] }} ";
            jsonContent = jsonContent.Replace("\"TOREPLACE\"", sercurityResponses);

            var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("BankingServices/Authorize", stringContent);

            HandleHttpErrors(response);
            
            var loginInfo = await response.Content.ReadAsAsync<AuthorizedResponse>();

            return loginInfo;
        }

        public async Task<AccountsDetailsResponse> GetAccountDetails(AuthorizedResponse loginInfo)
        {
            var jsonContent = JsonConvert.SerializeObject(new
            {
                RequestId = loginInfo.RequestId,
                WithAccountIdentity = true,
                WithTransactions = true,
                DaysOfTransactions = "Days90",
            });

            var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("BankingServices/GetAccountsDetail", stringContent);

            HandleHttpErrors(response);

            var accountDetails = await response.Content.ReadAsAsync<AccountsDetailsResponse>();

            return accountDetails;
        }

        private void InitializeHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Environment.BaseApiUrl);
            this.httpClient = client;
        }

        // Dummy handling but enough for the challenge
        private static void HandleHttpErrors(HttpResponseMessage authorizationInfo)
        {
            if (!authorizationInfo.IsSuccessStatusCode)
            {
                var message = $"Http Error - Status Code [{authorizationInfo.StatusCode}] Message: {authorizationInfo.ReasonPhrase}";
                Console.WriteLine(message);
                throw new HttpRequestException(authorizationInfo.ReasonPhrase);
            }
        }
    }
}
