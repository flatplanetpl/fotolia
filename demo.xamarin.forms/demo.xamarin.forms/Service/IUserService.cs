using System.Collections.Generic;
using System.Threading.Tasks;
using demo.xamarin.forms.Model;

namespace demo.xamarin.forms.Service
{
    public interface IUserService
    {
        List<User> Users { get; }
        Task LoadUsers(uint amount);
    }
}