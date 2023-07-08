using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input
{
    public enum PlayerID
    {
        Player_1,
        Player_2,
    }
    
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/InputReader")]
    public class InputReader : ScriptableObject,GameInput.IPlayer_1Actions,GameInput.IPlayer_2Actions
    {
        [SerializeField]
        private PlayerID _playerID;
        
        private GameInput _gameInput;

        public event UnityAction<float> XMoveEvent = delegate { };
        public event UnityAction<float> YMoveEvent = delegate { };
        public event UnityAction StrikeEvent = delegate {  };
        public event UnityAction StrikeCancledEvent = delegate {  };
        public event UnityAction MissEvent = delegate {  };
        public event UnityAction MissCancledEvent = delegate {  };

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                
            }
            
            switch (_playerID)
            {
                case PlayerID.Player_1:
                    _gameInput.Player_1.SetCallbacks(this);
                    _gameInput.Player_1.Enable();
                    break;
                case PlayerID.Player_2:
                    _gameInput.Player_2.SetCallbacks(this);
                    _gameInput.Player_2.Enable();
                    break;  
            }
        }

        public void OnXMove(InputAction.CallbackContext context)
        {
            XMoveEvent.Invoke(context.ReadValue<float>());
        }

        public void OnYMove(InputAction.CallbackContext context)
        {
            YMoveEvent.Invoke(context.ReadValue<float>());
        }

        public void OnStrike(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    StrikeEvent.Invoke();
                    break;
                
                case InputActionPhase.Canceled:
                    StrikeCancledEvent.Invoke();
                    break;
            }
        }

        public void OnMiss(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    MissEvent.Invoke();
                    break;
                
                case InputActionPhase.Canceled:
                    MissCancledEvent.Invoke();
                    break;
            }
        }
    }
}