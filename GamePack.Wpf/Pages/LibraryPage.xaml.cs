using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Enumerations;
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
            Games = new ObservableCollection<Game>(_gameService.GetGamesForUser(_userStore.CurrentUser.Id).OrderBy(x => x.Title));
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
            set 
            {
                _games = value;
                OnPropertyChanged();
            }
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

        private SortGamesOption _selectedSortByOption;
        public SortGamesOption SelectedSortByOption
        {
            get { return _selectedSortByOption; }
            set
            {
                _selectedSortByOption = value;
                OnPropertyChanged();
                SortGames(value);
            }
        }

        private void AddGame_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_addGamePageFactory.Create());
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
                MessageBox.Show($"Game {_selectedGame.Title} already runs!", "Launch Game");
                return;
            }

            Process process = null;

            try
            {
                process = Process.Start(_selectedGame.ExePath);
            }
            catch (Exception)
            {
                var result = MessageBox.Show($"Game '{_selectedGame.Title}' cannot be launched due to error. Do you want to delete it from your library?", "Launch Game", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes) 
                {
                    DeleteGame(_selectedGame);
                }
            }

            var game = _games.First(x => x.Id == _selectedGame.Id);
            game.LastRun = DateTime.UtcNow;
            game.ProcessName = process?.ProcessName;
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
                DeleteGame(_selectedGame);
            }
        }

        private void SortGames(SortGamesOption option)
        {
            switch (option)
            {
                case SortGamesOption.TitleAscending:
                    Games = new(_games.OrderBy(x => x.Title));
                    break;
                case SortGamesOption.TitleDescending:
                    Games = new(_games.OrderByDescending(x => x.Title));
                    break;
                case SortGamesOption.LastPlayedAscending:
                    Games = new(_games.OrderBy(x => x.LastRun).ToList());
                    break;
                case SortGamesOption.LastPlayedDescending:
                    Games = new(_games.OrderByDescending(x => x.LastRun).ToList());
                    break;
                default:
                    break;
            }

            CollectionViewSource.GetDefaultView(Games).Refresh();
        }

        private void DeleteGame(Game game)
        {
            _gameService.DeleteGame(game);
            MessageBox.Show($"Game '{game.Title}' has been deleted from your library.", "Delete Game");
            Games.Remove(game);
        }
    }
}
