using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page, INotifyPropertyChanged
    {
        private readonly IAbstractFactory<SignInPage> _signInPageFactory;
        private readonly IAbstractFactory<SignInWithGamepackPage> _signInWithGamePackPageFactory;
        private readonly IUserService _userService;

        public SignUpPage(
            IAbstractFactory<SignInPage> signInPageFactory,
            IAbstractFactory<SignInWithGamepackPage> signInWithGamePackPageFactory,
            IUserService userService)
        {
            DataContext = this;
            InitializeComponent();
            _signInPageFactory = signInPageFactory;
            _userService = userService;
            _signInWithGamePackPageFactory = signInWithGamePackPageFactory;
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

        private string _passwordConfirmation;
        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set
            {
                if (_passwordConfirmation != value)
                {
                    _passwordConfirmation = value;
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

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            ErorrMessageTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_passwordConfirmation))
            {
                ErrorMessage = "Username, password and password confirmation must be provided.";
                return;
            }
            else if (!_password.Equals(_passwordConfirmation))
            {
                ErrorMessage = "Password and password confirmation do not match.";
                return;
            }

            var userExists = _userService.CheckIfUserExists(_username);
            if (userExists)
            {
                ErrorMessage = "User with provided username already exists.";
                return;
            }

            var user = _userService.SignUp(_username, _password);
            ErorrMessageTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            ErrorMessage = "User account has been created, now you can Sign In.";
        }

        private void BackToSignInPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInPageFactory.Create());
            }
        }

        private void GoToSignInPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInWithGamePackPageFactory.Create());
            }
        }
    }
}
