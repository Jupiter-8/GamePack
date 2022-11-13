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
        private readonly IAbstractFactory<SignInWithGamepackPage> _signInWithGamepackPageFactory;

        public SignInPage(IAbstractFactory<SignInWithGamepackPage> signInWithGamepackPageFactory)
        {
            InitializeComponent();
            _signInWithGamepackPageFactory = signInWithGamepackPageFactory;
        }

        private void SignInWithGamePack_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInWithGamepackPageFactory.Create());
            }
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("../Pages/PreparingToLaunchStore.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("../Pages/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
