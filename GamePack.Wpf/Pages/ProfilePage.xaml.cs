using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private readonly UserStore _userStore;
        private readonly IUserService _userService;
        private readonly IAbstractFactory<SignInPage> _signInPageFactory;

        public ProfilePage(
            UserStore userStore,
            IUserService userService,
            IAbstractFactory<SignInPage> signInPageFactory)
        {
            DataContext = this;
            _userStore = userStore;
            _userService = userService;
            User = _userStore.CurrentUser;
            _signInPageFactory = signInPageFactory;
            InitializeComponent();
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteAccount_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to completely delete your account?", "Delete Account", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _userService.DeleteUser(_user);
                _userStore.SignOut();
                MessageBox.Show("Your account has been completely deleted, you will be redirected to the Sign In Menu");
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(_signInPageFactory.Create());
                ((MainWindow)Application.Current.MainWindow).SubFrame.Visibility = Visibility.Hidden;
            }
        }
    }
}
