using SellPoint.Data.Models;

namespace SellPoint.Presentation.WebClient.LocalStorage
{
    public class StateContainer
    {
        private User? savedUser;
        private List<Entidades> entidades;

        public List<Entidades> Entidades
        {
            get => entidades ?? new List<Entidades>();
            set
            {
                entidades = value;
                NotifyStateChanged();
            }
        }

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
