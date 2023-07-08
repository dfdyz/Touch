using UnityEngine;

namespace Assets.Scripts.UI
{
    [CreateAssetMenu(fileName = "UIAction", menuName = "Game/UIAction")]
    public class UIAction : ScriptableObject
    {
        [SerializeField]
        private GameObject startPannel;
        [SerializeField] 
        private GameObject chosePannel;
        [SerializeField] 
        private GameObject battlePannel;
        
        private GameObject CreateUICanvas(GameObject prefab)
        {
            // Time.timeScale = 0;
            var canvas = GameObject.Find("Canvas").transform;
            return Instantiate(prefab,canvas);
        }
        
        public void StartGame()
        {
            var _startPannel = GameObject.Find("StartPannel");
            _startPannel.SetActive(false);
            CreateUICanvas(chosePannel);
        }

        public void OnPlayerConfirm(int playerid)
        {
            Managers.Instance.PlayerConfirm(playerid);
        }


    }
}