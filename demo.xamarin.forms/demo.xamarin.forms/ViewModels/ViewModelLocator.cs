using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace demo.xamarin.forms.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<DetailPageViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HomePageViewModel Home
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }

        public DetailPageViewModel Details
        {
            get { return ServiceLocator.Current.GetInstance<DetailPageViewModel>(); }
        }
    }
}