using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System.Windows;
using System.Windows.Controls;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly IAbstractFactory<HomePage> _homePageFactory;
        private readonly IAbstractFactory<LibraryPage> _libraryPageFactory;
        private readonly IAbstractFactory<AccountPage> _accountPageFactory;
        private readonly IAbstractFactory<SettingsPage> _settingsPageFactory;
        private readonly IAbstractFactory<SignInPage> _signInPageFactory;
        private readonly UserStore _userStore;

        public MainPage(
            IAbstractFactory<HomePage> homePageFactory,
            IAbstractFactory<AccountPage> accountPageFactory,
            IAbstractFactory<SettingsPage> settingsPageFactory,
            IAbstractFactory<LibraryPage> libraryPageFactory,
            IAbstractFactory<SignInPage> signInPageFactory,
            UserStore userStore)
        {
            InitializeComponent();
            _homePageFactory = homePageFactory;
            _accountPageFactory = accountPageFactory;
            _settingsPageFactory = settingsPageFactory;
            _libraryPageFactory = libraryPageFactory;
            _signInPageFactory = signInPageFactory;
            _userStore = userStore;
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_homePageFactory.Create());
        }

        private void HomePage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_homePageFactory.Create());
            }
        }

        private void LibraryPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_libraryPageFactory.Create());
            }
        }

        private void AccountPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_accountPageFactory.Create());
            }
        }

        private void SettingsPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_settingsPageFactory.Create());
            }
        }

        private void SignOut_OnClick(object sender, RoutedEventArgs e)
        {
            _userStore.SignOut();
            NavigationService.Navigate(_signInPageFactory.Create());
            ((MainWindow)Application.Current.MainWindow).SubFrame.Visibility = Visibility.Hidden;
        }
    }
}
