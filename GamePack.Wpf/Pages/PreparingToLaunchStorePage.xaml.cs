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
        readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        public PreparingToLaunchStorePage()
        {
            InitializeComponent();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            _dispatcherTimer.Start();
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
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("Pages/LibraryPage.xaml", UriKind.RelativeOrAbsolute));
            }
            _dispatcherTimer.Stop();
        }
    }
}
