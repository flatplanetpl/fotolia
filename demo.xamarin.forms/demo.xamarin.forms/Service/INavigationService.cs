using System;
using System.Collections.Generic;
using demo.xamarin.forms.Model;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace demo.xamarin.forms
{
    public interface INavigationService
    {
        void NavigateToDetailPage(User user);

        void Initialize(Page page);

    }
}