using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using demo.xamarin.forms.Model;
using demo.xamarin.forms.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace demo.xamarin.forms.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;

        private RelayCommand _loadCommand;
        private uint _maxUsersCount = 10;
        private List<User> _users = new List<User>();
        private bool _isBusy;
        private User _selectedUser;

        public RelayCommand LoadCommand
        {
            get
            {
                return _loadCommand
                    ?? (_loadCommand = new RelayCommand(async () => await LoadUsers(), () => MaxUsersCount > 0 && IsEnabled));
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
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; RaisePropertyChanged(() => Users); }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (value == null)
                    return;
                _selectedUser = value;
                RaisePropertyChanged(() => SelectedUser);

            }
        }

        public uint MaxUsersCount
        {
            get { return _maxUsersCount; }
            set
            {
                _maxUsersCount = value; this.RaisePropertyChanged(() => MaxUsersCount); this.RaisePropertyChanged(() => LoadButtonText);
                LoadCommand.RaiseCanExecuteChanged();
            }
        }

        public string LoadButtonText => $"Load Users ({MaxUsersCount})";


        public HomePageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
            this.PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        private void MainPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedUser":
                    NavigateToDetails();
                    break;
            }
        }

        private void NavigateToDetails()
        {
            _navigationService.NavigateToDetailPage(SelectedUser);
        }

        private async Task LoadUsers()
        {
            try
            {
                IsBusy = true;
                await _userService.LoadUsers(MaxUsersCount);
                Users = _userService.Users;

            }
            catch (Exception e)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}