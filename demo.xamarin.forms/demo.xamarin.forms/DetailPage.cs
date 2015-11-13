using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.xamarin.forms.ViewModels;
using Xamarin.Forms;

namespace demo.xamarin.forms
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel viewModel)
        { 
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
