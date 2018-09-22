using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CapitalDummy.ResponseModels
{
    public class BaseFlinksResponse
    {
        public Guid RequestId { get; set; }
        public IList<Link> Links { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Institution { get; set; }
        public string Tag { get; set; }
    }

    public class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }
    }
}
