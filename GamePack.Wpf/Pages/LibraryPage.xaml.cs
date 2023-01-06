using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page, INotifyPropertyChanged
    {
        private readonly IAbstractFactory<AddGamePage> _addGamePageFactory;
        private readonly IGameService _gameService;
        private readonly UserStore _userStore;

        public LibraryPage(
            IAbstractFactory<AddGamePage> addGamePageFactory,
            IGameService gameService,
            UserStore userStore)
        {
            DataContext = this;
            _addGamePageFactory = addGamePageFactory;
            _gameService = gameService;
            _userStore = userStore;
            Games = new ObservableCollection<Game>(_gameService.GetGamesForUser(_userStore.CurrentUser.Id));
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> Games
        {
            get { return _games; }
            set { _games = value; }
        }

        private Game _selectedGame;
        public Game SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged();
            }
        }

        private void AddGame_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_addGamePageFactory.Create());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PlayGame_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedGame == null)
            {
                return;
            }

            var existingProcesses = Process.GetProcessesByName(_selectedGame.ProcessName);
            if (existingProcesses.Length != 0)
            {
                MessageBox.Show($"Game {_selectedGame.Title} already runs!");
                return;
            }

            var process = Process.Start(_selectedGame.ExePath);
            var game = _games.First(x => x.Id == _selectedGame.Id);
            game.LastRun = DateTime.UtcNow;
            game.ProcessName = process.ProcessName;
            _gameService.UpdateGame(game);
            CollectionViewSource.GetDefaultView(Games).Refresh();
        }

        private void DeleteGame_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedGame == null)
            {
                return;
            }

            var result = MessageBox.Show($"Are you sure that you want to delete game '{_selectedGame.Title}' from your library?", "Delete Game", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _gameService.DeleteGame(_selectedGame);
                MessageBox.Show($"Game '{_selectedGame.Title}' has been deleted from your library.");
                Games.Remove(_selectedGame);
            }
        }
    }
}
