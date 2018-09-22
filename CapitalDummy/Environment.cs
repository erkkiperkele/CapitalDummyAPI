using CapitalDummy.Models;

namespace CapitalDummy
{
    public static class Environment
    {
        public static readonly string BaseApiUrl = "https://sandbox.flinks.io/v3/f791f187-afad-4f43-b8ca-04a8995fa660/";

        public static readonly AccountCredentials CapitalDummyCredentials = new AccountCredentials
        {
            Institution = "FlinksCapital",
            Password = "Everyday",
            Username = "Greatday",
            SecurityQuestions = new[]
            {
                new AccountSecurityQuestion { Question = "What city were you born in?", Answer = "Montreal"},
                new AccountSecurityQuestion { Question = "What is the best country on earth?", Answer = "Canada"},
                new AccountSecurityQuestion { Question = "What shape do people like most?", Answer = "Triangle"}
            }
        };
    }
}
