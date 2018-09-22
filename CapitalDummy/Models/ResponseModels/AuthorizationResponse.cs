using System;
using System.Collections.Generic;
using System.Net;

namespace CapitalDummy.ResponseModels
{
    public class AuthorizationResponse : BaseFlinksResponse
    {
        public IList<SecurityChallenge> SecurityChallenges { get; set; }
    }

    public class SecurityChallenge
    {
        public string Type { get; set; }
        public string Prompt { get; set; }
    }
}
