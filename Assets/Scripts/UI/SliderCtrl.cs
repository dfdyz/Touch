using System;
using Input;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI
{
    public class SliderCtrl : MonoBehaviour
    {
        [SerializeField] 
        private float totalPoint;
        
        [SerializeField]
        private InputReader inputReader;

        [SerializeField] 
        private UIAction uiAction;

        [SerializeField] 
        private Text massText;

        [SerializeField] 
        private Text speedText;

        [SerializeField] 
        private GameObject confirmImage;
        
        public Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }

        private void OnEnable()
        {
            inputReader.XMoveEvent += OnXMove;
            inputReader.StrikeEvent += OnConfirm;
        }

        private void OnXMove(float value)
        {
            slider.value += value;
            massText.text = slider.value.ToString();
            speedText.text = (slider.maxValue - slider.value).ToString();
        }

        private void OnConfirm()
        {
            confirmImage.SetActive(true);

            if (inputReader._playerID == PlayerID.Player_1)
            {            
                uiAction.OnPlayerConfirm(1);
                Managers.addMass_1 = (slider.value / slider.maxValue) * totalPoint;
                Managers.addSpeed_1 = (1-slider.value / slider.maxValue) * totalPoint;
            }
                
            if (inputReader._playerID == PlayerID.Player_2)
            {
                uiAction.OnPlayerConfirm(2);
                Managers.addMass_2 = (slider.value / slider.maxValue) * totalPoint;
                Managers.addSpeed_2 = (1-slider.value / slider.maxValue) * totalPoint;
            }
        }

        private void OnDisable()
        {
            inputReader.XMoveEvent -= OnXMove;
            inputReader.StrikeEvent -= OnConfirm;
        }
    }
}