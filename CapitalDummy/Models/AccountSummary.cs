using System;
using System.Collections.Generic;

namespace CapitalDummy.Models
{
    public class AccountSummary
    {
        // Warning: keep the properties order to reflect the exact same result as 
        // required by the challenge when serializing
        public Guid LoginId { get; set; }
        public Guid RequestId { get; set; }
        public UserSummary Holder { get; set; }
        public IList<OperationSummary> OperationAccounts { get; set; }
        public IList<USDAccountSummary> USDAccounts { get; set; }
        public Guid BiggestCreditTrxId { get; set; }
    }
}
