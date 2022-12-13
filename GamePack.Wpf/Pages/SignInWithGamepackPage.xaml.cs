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
    /// Interaction logic for SignInWithGamepackPage.xaml
    /// </summary>
    public partial class SignInWithGamepackPage : Page, INotifyPropertyChanged
    {
        private readonly IAbstractFactory<SignInPage> _signInPageFactory;
        private readonly IAbstractFactory<PreparingToLaunchStorePage> _preparingToLaunchStorePageFactory;
        private readonly IAbstractFactory<SignUpPage> _signUpPageFactory;
        private readonly IUserService _userService;
        private readonly UserStore _userStore;

        public SignInWithGamepackPage(
            IUserService userService,
            IAbstractFactory<SignInPage> signInPageFactory,
            IAbstractFactory<PreparingToLaunchStorePage> preparingToLaunchStorePageFactory,
            IAbstractFactory<SignUpPage> signUpPageFactory,
            UserStore userStore)
        {
            DataContext = this;
            _userService = userService;
            InitializeComponent();
            _signInPageFactory = signInPageFactory;
            _preparingToLaunchStorePageFactory = preparingToLaunchStorePageFactory;
            _userStore = userStore;
            _signUpPageFactory = signUpPageFactory;
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                ErrorMessage = "Username and password must be provided.";
                return;
            }

            var user = _userService.SignIn(_username, _password);

            if (user == null)
            {
                ErrorMessage = "Cannot Sign In, username or password is wrong";
                return;
            }

            _userStore.SignIn(user);
            ErrorMessage = string.Empty;
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_preparingToLaunchStorePageFactory.Create());
            }
        }

        private void BackToSignInPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInPageFactory.Create());
            }
        }

        private void GoToSignUpPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signUpPageFactory.Create());
            }
        }
    }
}
