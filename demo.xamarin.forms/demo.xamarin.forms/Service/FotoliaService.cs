using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using demo.xamarin.forms.Service;
using ModernHttpClient;
using Newtonsoft.Json;

namespace XApp1.Service
{
    public class FotoliaService : IFotoliaService
    {
        private HttpClient _wc;
        private readonly string _basicAuthHeader;
        private const string ApiKey = "TuZMIRBmrifnAJ1MvmJxg8MP5Ofogvj0";
        public string SearchFormatUrl { get; } = "http://api.fotolia.com/Rest/1/search/getSearchResults?search_parameters[words]={0}&search_parameters[limit]={1}";

        public FotoliaService()
        {
            var key = Encoding.GetEncoding("ISO-8859-1").GetBytes($"{ApiKey}:");
            _basicAuthHeader = System.Convert.ToBase64String(key);
            var moderHandler=new  NativeMessageHandler();
            _wc = new HttpClient(moderHandler);
            _wc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _basicAuthHeader);
            

        }

        public async Task<List<FotoliaPhoto>> Search(string phrase, int count)
        {
            var result = new List<FotoliaPhoto>();
            var url = string.Format(SearchFormatUrl, phrase,count);
            var json = await _wc.GetStringAsync(url);
            
            ExpandoObject jsonObject = JsonConvert.DeserializeObject<ExpandoObject>(json);

            var rootList = (IDictionary<string, dynamic>)jsonObject;

            foreach (var item in rootList.Values)
            {
                var itemDictionary = item as IDictionary<string, dynamic>;
                if (itemDictionary == null)
                    continue;

                var photo = new FotoliaPhoto
                {
                    Author = itemDictionary["creator_name"],
                    Name = itemDictionary["title"],
                    ThumbnailUrl = itemDictionary["thumbnail_110_url"],
                    PhotoUrl= itemDictionary["thumbnail_400_url"],

                };

                result.Add(photo);
            }

            return result;
        }
    }
}