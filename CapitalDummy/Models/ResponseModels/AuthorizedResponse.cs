using System;

namespace CapitalDummy.ResponseModels
{
    public class AuthorizedResponse: BaseFlinksResponse
    {
        public Login Login { get; set; }
    }

    public class Login
    {
        public string Username { get; set; }
        public bool IsScheduledRefresh { get; set; }
        public DateTimeOffset LastRefresh { get; set; }
        public Guid Id { get; set; }
    }
}
