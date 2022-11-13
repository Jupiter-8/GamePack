using GamePack.Wpf.Factories;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        private readonly IAbstractFactory<SignInPage> _signInPageFactory;
        private readonly DispatcherTimer _dispatcherTimer;

        public LoadingPage(IAbstractFactory<SignInPage> signInPageFactory)
        {
            _dispatcherTimer = new DispatcherTimer();
            _signInPageFactory = signInPageFactory;
            InitializeComponent();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick!;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5);
            _dispatcherTimer.Start();
        }

        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Application.Current.MainWindow != null)
            {
                NavigationService.Navigate(_signInPageFactory.Create());
            }
            _dispatcherTimer.Stop();
        }
    }
}
