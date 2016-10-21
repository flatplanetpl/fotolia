using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using demo.xamarin.forms.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XApp1.Service;

namespace demo.xamarin.forms.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private RelayCommand _loadCommand;
        private int _maxPhotosCount = 10;
        private List<FotoliaPhoto> _photos = new List<FotoliaPhoto>();
        private bool _isBusy;
        private FotoliaPhoto _selectedPhoto;
        private IFotoliaService _fotoliaService;
        private string _searchPhrase;

        public RelayCommand LoadCommand
        {
            get
            {
                return _loadCommand
                    ?? (_loadCommand = new RelayCommand(async () => await LoadUsers(), () => MaxPhotosCount > 0 && IsEnabled));
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value; RaisePropertyChanged(() => IsBusy);
                RaisePropertyChanged(() => IsEnabled);
                LoadCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEnabled => !IsBusy;
        public List<FotoliaPhoto> Photos
        {
            get { return _photos; }
            set { _photos = value; RaisePropertyChanged(() => Photos); }
        }

        public FotoliaPhoto SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                if (value == null)
                    return;
                _selectedPhoto = value;
                RaisePropertyChanged(() => SelectedPhoto);

            }
        }

        public int MaxPhotosCount
        {
            get { return _maxPhotosCount; }
            set
            {
                _maxPhotosCount = value; this.RaisePropertyChanged(() => MaxPhotosCount); this.RaisePropertyChanged(() => LoadButtonText);
                LoadCommand.RaiseCanExecuteChanged();
            }
        }

        public string SearchPhrase
        {
            get { return _searchPhrase; }
            set
            {
                if (value == null)
                    return;
                _searchPhrase = value;
                RaisePropertyChanged(() => SearchPhrase);
                LoadCommand.RaiseCanExecuteChanged();
            }
        }

        public string LoadButtonText => $"Search Users ({MaxPhotosCount})";


        public HomePageViewModel(INavigationService navigationService, IFotoliaService fotoliaService)
        {
            _navigationService = navigationService;
            _fotoliaService = fotoliaService;
            this.PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        private void MainPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedPhoto":
                    NavigateToDetails();
                    break;
            }
        }

        private void NavigateToDetails()
        {
            _navigationService.NavigateToDetailPage(SelectedPhoto);
        }

        private async Task LoadUsers()
        {
            try
            {
                IsBusy = true;
                
                Photos = await _fotoliaService.Search(SearchPhrase, MaxPhotosCount); ;

            }
            catch (Exception e)
            {
                //todo: handle exception
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}