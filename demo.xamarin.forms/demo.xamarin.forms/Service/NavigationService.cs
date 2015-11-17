using System.Collections.Generic;
using demo.xamarin.forms.Model;
using demo.xamarin.forms.ViewModels;
using Xamarin.Forms;

namespace demo.xamarin.forms
{
    public class NavigationService : INavigationService
    {
        private INavigation _navigation;

        public void NavigateToDetailPage(User user)
        {
            var viewModel = App.Locator.Details;
            viewModel.User = user;

            var page = new DetailPage(viewModel);
          
            _navigation.PushAsync(page);
        }

        public void Initialize(Page page)
        {
            _navigation = page.Navigation;
        }
    }
}