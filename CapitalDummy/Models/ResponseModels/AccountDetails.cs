using System;
using System.Collections.Generic;

namespace CapitalDummy.ResponseModels
{
    public class AccountsDetailsResponse : AuthorizedResponse
    {
        public IList<AccountDetails> Accounts { get; set; }
    }

    public class AccountDetails
    { 
        public IList<Transaction> Transactions { get; set; }
        public int? TransitNumber { get; set; }
        public int? InstitutionNumber { get; set; }
        public double OverdraftLimit { get; set; }
        public string Title { get; set; }
        public string AccountNumber { get; set; }
        public Balance Balance { get; set; }
        public Catergory Category { get; set; }
        public string Type { get; set; }
        public Currency Currency { get; set; }
        public Holder Holder { get; set; }
        public Guid Id { get; set; }
    }

    public class Balance
    {
        public double Current { get; set; }
        public double? Limit { get; set; }
    }

    public class Holder
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Transaction
    {
        public Guid Id { get; set; }
        public double? Credit { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
