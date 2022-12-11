using GamePack.Wpf.Stores;
using System.Windows.Controls;

namespace GamePack.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly UserStore _userStore;

        public HomePage(UserStore userStore)
        {
            InitializeComponent();
            _userStore = userStore;
            userNameTxtBlock.Text = _userStore.CurrentUser?.Username;
        }
    }
}
