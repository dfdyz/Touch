using System;
using UnityEngine;

namespace Input
{
    public class PlayerInput : MonoBehaviour
    {
        
        [SerializeField] private InputReader _inputReader;

        private float x_input;
        private float y_input;
        private bool onStrike;
        private bool onMiss;
        private Vector3 direction = new Vector3(0,0,0);

        public bool IsStriking => onStrike;
        public bool IsMissing => onMiss;
        public Vector3 Direction
        {
            get
            {
                direction.x = x_input;
                direction.y = y_input;
                return direction;
            }
        }

        private void OnEnable()
        {
            _inputReader.XMoveEvent += OnXMove;
            _inputReader.YMoveEvent += OnYMove;
            _inputReader.StrikeEvent += OnStrike;
            _inputReader.StrikeCancledEvent += OnStrikeCancled;
            _inputReader.MissEvent += OnMiss;
            _inputReader.MissCancledEvent += OnMissCancled;
        }
        
        private void OnDisable()
        {
            _inputReader.XMoveEvent -= OnXMove;
            _inputReader.YMoveEvent -= OnYMove;
            _inputReader.StrikeEvent -= OnStrike;
            _inputReader.StrikeCancledEvent -= OnStrikeCancled;
            _inputReader.MissEvent -= OnMiss;
            _inputReader.MissCancledEvent -= OnMissCancled;
        }

        private void OnXMove(float value)
        {
            Debug.Log($"Move : " + x_input);
            x_input = value;
        }

        private void OnYMove(float value) => y_input = value;
        private void OnStrike() => onStrike = true;
        private void OnStrikeCancled() => onStrike = false;
        private void OnMiss() => onMiss = true;
        private void OnMissCancled() => onMiss = false;
        
        
    }
}