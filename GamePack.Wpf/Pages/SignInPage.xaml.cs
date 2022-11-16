using GamePack.Wpf.Factories;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private readonly IAbstractFactory<PreparingToLaunchStorePage> _preparingToLaunchStorePageFactory;
        private readonly IAbstractFactory<SignInWithGamepackPage> _signInWithGamepackPageFactory;
        private readonly IAbstractFactory<SignUpPage> _signUpPageFactory;

        public SignInPage(
            IAbstractFactory<SignInWithGamepackPage> signInWithGamepackPageFactory,
            IAbstractFactory<SignUpPage> signUpPageFactory,
            IAbstractFactory<PreparingToLaunchStorePage> preparingToLaunchStorePageFactory)
        {
            InitializeComponent();
            _signInWithGamepackPageFactory = signInWithGamepackPageFactory;
            _signUpPageFactory = signUpPageFactory;
            _preparingToLaunchStorePageFactory = preparingToLaunchStorePageFactory;
        }

        private void SignInWithGamePack_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInWithGamepackPageFactory.Create());
            }
        }

        private void SignInLater_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_preparingToLaunchStorePageFactory.Create());
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("../Pages/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(_signUpPageFactory.Create());
            }
        }
    }
}
