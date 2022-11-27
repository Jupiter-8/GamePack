using GamePack.Wpf.Factories;
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
        private readonly IAbstractFactory<MainPage> _mainPageFactory;
        private readonly DispatcherTimer _dispatcherTimer;

        public PreparingToLaunchStorePage(IAbstractFactory<MainPage> mainPageFactory)
        {
            InitializeComponent();
            _dispatcherTimer = new();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            _dispatcherTimer.Start();
            _mainPageFactory = mainPageFactory;
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
                NavigationService.Navigate(_mainPageFactory.Create());
                ((MainWindow)Application.Current.MainWindow).SubFrame.Visibility = Visibility.Visible;
            }
            _dispatcherTimer.Stop();
        }
    }
}
