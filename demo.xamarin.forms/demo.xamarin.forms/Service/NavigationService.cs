using System.Collections.Generic;
using demo.xamarin.forms.ViewModels;
using Xamarin.Forms;
using XApp1.Service;

namespace demo.xamarin.forms
{
    public class NavigationService : INavigationService
    {
        private INavigation _navigation;

        public void NavigateToDetailPage(FotoliaPhoto photo)
        {
            var viewModel = App.Locator.Details;
            viewModel.Photo = photo;

            var page = new DetailPage(viewModel);
          
            _navigation.PushAsync(page);
        }

        public void Initialize(Page page)
        {
            _navigation = page.Navigation;
        }
    }
}