using SellPoint.Data.Models;

namespace SellPoint.Presentation.WebClient.LocalStorage
{
    public class StateContainer
    {
        private User? savedUser;

        public User user
        {
            get => savedUser ?? null;
            set
            {
                savedUser = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
