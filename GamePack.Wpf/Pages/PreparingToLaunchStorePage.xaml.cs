using GamePack.Wpf.Factories;
using GamePack.Wpf.Stores;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for PreparingToLaunchStore.xaml
    /// </summary>
    public partial class PreparingToLaunchStorePage : Page
    {
        private readonly IAbstractFactory<LibraryPage> _libraryPageFactory;
        readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly UserStore _userStore;

        public PreparingToLaunchStorePage(
            UserStore userStore,
            IAbstractFactory<LibraryPage> libraryPageFactory)
        {
            InitializeComponent();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            _dispatcherTimer.Start();
            _userStore = userStore;
            _libraryPageFactory = libraryPageFactory;
        }

        private void _dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            MainGrid.Height = 220;
            ProgressBar.Visibility = Visibility.Visible;

            _dispatcherTimer.Tick += _dispatcherTimer_Tick1;
            _dispatcherTimer.Stop();

            _dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimer.Start();
        }

        private void _dispatcherTimer_Tick1(object? sender, EventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_libraryPageFactory.Create());
            }
            _dispatcherTimer.Stop();
        }
    }
}
