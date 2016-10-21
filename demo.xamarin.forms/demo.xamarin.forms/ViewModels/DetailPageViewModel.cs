using System.Collections.Generic;
using GalaSoft.MvvmLight;
using XApp1.Service;

namespace demo.xamarin.forms.ViewModels
{
    public class DetailPageViewModel: ViewModelBase
    {
        private FotoliaPhoto _photo;

        public FotoliaPhoto Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
    }
}