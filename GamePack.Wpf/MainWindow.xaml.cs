using GamePack.Wpf.Factories;
using GamePack.Wpf.Pages;
using System;
using System.Windows;

namespace GamePack.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Func<LoadingPage> _loadingPageFactory { get; }

        public MainWindow(IAbstractFactory<LoadingPage> loadingPageFactory)
        {
            InitializeComponent();
            // _loadingPageFactory = loadingPageFactory;
            var loadingPage = loadingPageFactory.Create();
            MainFrame.Navigate(loadingPage);
        }
    }
}
