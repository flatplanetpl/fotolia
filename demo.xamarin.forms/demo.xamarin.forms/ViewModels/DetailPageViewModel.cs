using System.Collections.Generic;
using demo.xamarin.forms.Model;
using GalaSoft.MvvmLight;

namespace demo.xamarin.forms.ViewModels
{
    public class DetailPageViewModel: ViewModelBase
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}