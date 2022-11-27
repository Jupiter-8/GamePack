using GamePack.Domain.Entities;
using System;

namespace GamePack.Wpf.Stores
{
    public class UserStore
    {
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                CurrentUserChanged?.Invoke();
            }
        }

        public bool IsSignedIn => CurrentUser != null;

        public event Action CurrentUserChanged;

        public void SignIn(User user) => CurrentUser = user;

        public void SignOut() => CurrentUser = null;
    }
}
