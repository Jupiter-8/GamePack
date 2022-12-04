﻿using GamePack.Services.Interfaces;
using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for AddGamePage.xaml
    /// </summary>
    public partial class AddGamePage : Page, INotifyPropertyChanged
    {
        private readonly IAbstractFactory<LibraryPage> _libraryPageFactory;
        private readonly UserStore _userStore;
        private readonly IGameService _gameService;

        public AddGamePage(
            IAbstractFactory<LibraryPage> libraryPageFactory,
            UserStore userStore,
            IGameService gameService)
        {
            DataContext = this;
            InitializeComponent();
            _libraryPageFactory = libraryPageFactory;
            _userStore = userStore;
            _gameService = gameService;
        }

        private string _gameTitle;
        public string GameTitle
        {
            get { return _gameTitle; }
            set
            {
                if (_gameTitle != value)
                {
                    _gameTitle = value;
                    IsDataValid = !string.IsNullOrEmpty(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _exePath;
        public string ExePath
        {
            get { return _exePath; }
            set
            {
                if (_exePath != value)
                {
                    _exePath = value;
                    IsDataValid = !string.IsNullOrEmpty(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isDataValid;
        public bool IsDataValid
        {
            get { return _isDataValid; }
            set
            {
                if (_isDataValid != value)
                {
                    _isDataValid = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SelectExePath_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var exePath = openFileDialog.FileName;
                if (exePath.EndsWith(".exe"))
                {
                    ExePath = exePath;
                    GameTitle = openFileDialog.SafeFileName[..3];
                    ErrorMessage = string.Empty;
                }
                else
                {
                    ErrorMessage = "Provided file must be an exe file.";
                }
            }
        }

        private void ConfirmAddGame_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIsDataValid())
            {
                _gameService.AddGame(_gameTitle, _exePath, 1, _userStore.CurrentUser.Id);
            }
        }

        private void BackToLibraryPage_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).SubFrame.Navigate(_libraryPageFactory.Create());
        }

        private bool CheckIsDataValid()
        {
            if (string.IsNullOrEmpty(_gameTitle) || string.IsNullOrEmpty(_exePath))
            {
                ErrorMessage = "You must provide game title and exe path.";
                return false;
            }
            else if (!_exePath.EndsWith(".exe"))
            {
                ErrorMessage = "Provided file must be an exe file.";
                return false;
            }

            ErrorMessage = string.Empty;
            return true;
        }
    }
}