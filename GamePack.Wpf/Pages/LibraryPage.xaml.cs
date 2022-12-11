using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

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
            Games = _gameService.GetGamesForUser(_userStore.CurrentUser.Id);
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Game> _games;
        public List<Game> Games
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

            var process = Process.Start(_selectedGame.ExePath);
            _selectedGame.LastRun = DateTime.UtcNow;
            _gameService.UpdateGame(_selectedGame);
        }
    }
}
