using GamePack.Wpf.Commands;
using GamePack.Wpf.Stores;
using System.Windows.Input;

namespace GamePack.Wpf.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public LibraryViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }
    }
}
