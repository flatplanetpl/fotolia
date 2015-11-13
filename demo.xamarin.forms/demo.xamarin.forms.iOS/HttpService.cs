using System.Net.Http;
using System.Threading.Tasks;
using demo.xamarin.forms.Service;
using Newtonsoft.Json;

namespace demo.xamarin.forms.iOS
{
    public class HttpService:IHttpService
    {
        private HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient(new ModernHttpClient.NativeMessageHandler(false,true));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var json = await  _httpClient.GetStringAsync(url);
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}