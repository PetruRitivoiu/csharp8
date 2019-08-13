using System.Net.Http;
using System.Threading.Tasks;

namespace UsingDeclarations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var res = await httpClient.GetAsync("https://google.com");
        }
    }
}
