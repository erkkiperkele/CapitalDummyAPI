using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CapitalDummy.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var stringContent = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}
