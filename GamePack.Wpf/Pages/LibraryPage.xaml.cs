using GamePack.Wpf.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        private readonly IAbstractFactory<HomePage> _homePageFactory;
        private readonly IAbstractFactory<ProfilePage> _libraryPageFactory;
        private readonly IAbstractFactory<ProfilePage> _profilePageFactory;
        private readonly IAbstractFactory<SettingsPage> _settingsPageFactory;

        public LibraryPage(
            IAbstractFactory<HomePage> homePageFactory,
            IAbstractFactory<ProfilePage> profilePageFactory,
            IAbstractFactory<SettingsPage> settingsPageFactory,
            IAbstractFactory<ProfilePage> libraryPageFactory)
        {
            InitializeComponent();
            _homePageFactory = homePageFactory;
            _profilePageFactory = profilePageFactory;
            _settingsPageFactory = settingsPageFactory;
            _libraryPageFactory = libraryPageFactory;
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

        private void ProfilePage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_profilePageFactory.Create());
            }
        }

        private void SettingsPage_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_settingsPageFactory.Create());
            }
        }
    }
}
