using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputMgr : MonoBehaviour
    {
        [SerializeField]
        private InputReader inputReader_1;

        [SerializeField]
        private InputReader inputReader_2;

        private List<KeyMapping> key_mappings = new List<KeyMapping>();

        private float prevH1;
        private float prevH2;
        private float prevV1;
        private float prevV2;

        private float curH1;
        private float curH2;
        private float curV1;
        private float curV2;

        private void Start()
        {
            AddKeyMapping(KeyCode.F, inputReader_1.OnStrike);
            AddKeyMapping(KeyCode.G, inputReader_1.OnMiss);
            AddKeyMapping(KeyCode.Comma, inputReader_2.OnStrike);
            AddKeyMapping(KeyCode.Period, inputReader_2.OnMiss);


        }

        private void AddKeyMapping(KeyCode k, KeyMapping.KeyEvent e)
        {
            key_mappings.Add(new KeyMapping(k,e));
        }
        
        
        private void Update()
        {
            foreach (var km in key_mappings)
            {
                km.OnUpdate();
            }

            curH1 = UnityEngine.Input.GetAxisRaw("Horizontal_1");
            curV1 = UnityEngine.Input.GetAxisRaw("Vertical_1");
            curH2 = UnityEngine.Input.GetAxisRaw("Horizontal_2");
            curV2 = UnityEngine.Input.GetAxisRaw("Vertical_2");
            
            BindAxis();
        }

        private void BindAxis()
        {
            if (Math.Abs(curH1 - prevH1) > 0.02f)
            {
                inputReader_1.OnXMove(curH1);
                prevH1 = curH1;
                
                print(curH1);
            }
            
            if (Math.Abs(curV1 - prevV1) > 0.02f)
            {
                inputReader_1.OnYMove(curV1);
                prevV1 = curV1;
            }
            
            if (Math.Abs(curH2 - prevH2) > 0.02f)
            {
                inputReader_2.OnXMove(curH2);
                prevH2 = curH2;
            }
            
            if (Math.Abs(curV2 - prevV2) > 0.02f)
            {
                inputReader_2.OnYMove(curV2);
                prevV2 = curV2;
            }
        }
        
        public class KeyMapping
        {
            public delegate void KeyEvent(bool pressed);

            public KeyEvent e;
            
            private KeyCode k;
            public KeyMapping(KeyCode key, KeyEvent keyEvent)
            {
                k = key;
                e = keyEvent;
            }

            public void OnUpdate()
            {
                if(UnityEngine.Input.GetKeyDown(k))
                    e(true);
                else if(UnityEngine.Input.GetKeyUp(k))
                    e(false);
            }
            
            
        }
        
    }
}