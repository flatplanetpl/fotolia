using System;
using System.Threading.Tasks;

namespace demo.xamarin.forms.Service
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
    }
}