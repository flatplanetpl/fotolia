using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using demo.xamarin.forms.Service;
using Newtonsoft.Json;

namespace demo.xamarin.forms.Droid
{
    [Activity(Label = "demo.xamarin.forms", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            App.IoC.Register<IHttpService, HttpService>();

        
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
    public class HttpService : IHttpService
    {

        private HttpClient _httpClient;

        static HttpService()
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate
            {
                return true;
            };
        }

        public HttpService()
        {
            _httpClient = new HttpClient(new ModernHttpClient.NativeMessageHandler(false, true));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var json = await _httpClient.GetStringAsync(url);
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}

