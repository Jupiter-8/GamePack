using GamePack.Wpf.Factories;
using System.Windows;
using System.Windows.Controls;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        private readonly IAbstractFactory<AddGamePage> _addGamePageFactory;

        public LibraryPage(IAbstractFactory<AddGamePage> addGamePageFactory)
        {
            InitializeComponent();
            _addGamePageFactory = addGamePageFactory;
        }

        private void AddGame_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_addGamePageFactory.Create());
        }
    }
}
