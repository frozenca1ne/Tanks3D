using UnityEngine;

namespace Managers
{
    public abstract class GameState : MonoBehaviour
    {
        protected GameManager context;

        public GameManager Context
        {
            get => context;
            set => context = value;
        }

        public abstract void Handle();
    }
}
