using System.Collections.Generic;
using System.Threading.Tasks;
using XApp1.Service;

namespace demo.xamarin.forms.Service
{
    public interface IFotoliaService
    {
        Task<List<FotoliaPhoto>> Search(string phrase, int count);
    }
}