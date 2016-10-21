using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using XApp1.Service;

namespace demo.xamarin.forms
{
    public interface INavigationService
    {
        void NavigateToDetailPage(FotoliaPhoto photo);

        void Initialize(Page page);

    }
}