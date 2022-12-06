using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System.Collections.Generic;
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
        private readonly IGameService _gameService;
        private readonly UserStore _userStore;

        public LibraryPage(
            IAbstractFactory<AddGamePage> addGamePageFactory,
            IGameService gameService,
            UserStore userStore)
        {
            InitializeComponent();
            _addGamePageFactory = addGamePageFactory;
            _gameService = gameService;
            _userStore = userStore;

            Games = _gameService.GetGamesForUser(_userStore.CurrentUser.Id);


            System.Console.WriteLine("Games: " + Games.Count);
            foreach (var game in Games)
            {
                System.Console.WriteLine(game.Title);
            }
        }

        private List<Game> _games;
        public List<Game> Games
        {
            get { return _games; }
            set { _games = value; }
        }

        private void AddGame_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_addGamePageFactory.Create());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
