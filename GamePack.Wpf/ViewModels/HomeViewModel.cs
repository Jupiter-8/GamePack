using GamePack.Wpf.Commands;
using GamePack.Wpf.Stores;
using System.Windows.Input;

namespace GamePack.Wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateLibraryCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateLibraryCommand = new NavigateCommand<LibraryViewModel>(navigationStore, () => new LibraryViewModel(navigationStore));
        }
    }
}
