using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input
{
    public enum PlayerID
    {
        Player_1 = 1,
        Player_2 = 2,
    }
    
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/InputReader")]
    public class InputReader : ScriptableObject
    {
        public PlayerID _playerID;
        
        private GameInput _gameInput;

        public event UnityAction<float> XMoveEvent = delegate { };
        public event UnityAction<float> YMoveEvent = delegate { };
        public event UnityAction StrikeEvent = delegate {  };
        public event UnityAction StrikeCancledEvent = delegate {  };
        public event UnityAction MissEvent = delegate {  };
        public event UnityAction MissCancledEvent = delegate {  };

        private void OnEnable()
        {
            // if (_gameInput == null)
            // {
            //     _gameInput = new GameInput();
            //     
            // }
            //
            // switch (_playerID)
            // {
            //     case PlayerID.Player_1:
            //         _gameInput.Player_1.SetCallbacks(this);
            //         _gameInput.Player_1.Enable();
            //         break;
            //     case PlayerID.Player_2:
            //         _gameInput.Player_2.SetCallbacks(this);
            //         _gameInput.Player_2.Enable();
            //         break;  
            // }
        }

        public void OnXMove(float value)
        {
            XMoveEvent.Invoke(value);
        }

        public void OnYMove(float value)
        {
            YMoveEvent.Invoke(value);
        }

        public void OnStrike(bool pressed)
        {
            switch (pressed)
            {
                case true:
                    StrikeEvent.Invoke();
                    break;
                
                case false:
                    StrikeCancledEvent.Invoke();
                    break;
            }
        }

        public void OnMiss(bool pressed)
        {
            switch (pressed)
            {
                case true:
                    MissEvent.Invoke();
                    break;
                
                case false:
                    MissCancledEvent.Invoke();
                    break;
            }
        }
    }
}