using System.Collections.Generic;

namespace CapitalDummy.Models
{
    public class AccountCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Institution { get; set; }

        public IList<AccountSecurityQuestion> SecurityQuestions { get; set; }
    }
}
