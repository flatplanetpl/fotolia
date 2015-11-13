using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using demo.xamarin.forms.Service;
using demo.xamarin.forms.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace demo.xamarin.forms
{
    public class App : Application
    {

        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public static SimpleIoc IoC => SimpleIoc.Default;

        public App()
        {
           
            var navigationService = new NavigationService();

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IUserService,UserService>();
            // The root page of your application
            var homePage = new HomePage();
            MainPage = new NavigationPage(homePage);
         
            navigationService.Initialize(MainPage);

        }

        protected override void OnStart()
        {
           
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
    
}
