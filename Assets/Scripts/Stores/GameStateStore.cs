using System;
using UnityEngine;
using UnityEngine.Events;

namespace Stores
{
    class GameStateStore : MonoBehaviour
    {
        [Serializable]
        public class StateChangeEvent : UnityEvent<GameState> { }

        [SerializeField]
        private GameState state;

        [SerializeField]
        private StateChangeEvent onStateChange;

        public void Forward()
        {
            switch (state)
            {
                case GameState.Start:
                    state = GameState.Game;
                    break;
                case GameState.Game:
                    state = GameState.Result;
                    break;
                case GameState.Result:
                    state = GameState.Start;
                    break;
            }
            NotifyCurrentState();
        }

        private void Start()
        {
            NotifyCurrentState();
        }

        private void NotifyCurrentState()
        {
            onStateChange.Invoke(state);
        }
    }
}