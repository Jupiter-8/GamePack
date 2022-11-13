using GamePack.DataAccess;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using System;
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
        private readonly IUserService _userService;

        public SignInWithGamepackPage(IUserService userService, IAbstractFactory<SignInPage> signInPageFactory)
        {
            DataContext = this;
            _userService = userService;
            InitializeComponent();
            _signInPageFactory = signInPageFactory;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var user = _userService.SignIn(_username, _password);
            Console.WriteLine();
        }

        private void BackToSignInPage_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInPageFactory.Create());
            }
        }
    }
}
