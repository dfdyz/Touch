using UnityEngine;
using UnityEngine.SceneManagement;

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
        [SerializeField]
        private GameObject winPannel;
        [SerializeField]
        private GameObject teachPannel;

        private GameObject _teachPannel;

        private GameObject CreateUICanvas(GameObject prefab)
        {
            // Time.timeScale = 0;
            var canvas = GameObject.Find("Canvas").transform;
            return Instantiate(prefab,canvas);
        }
        
        public void StartGame()
        {
            var _startPannel = GameObject.Find("StartPannel");
            var anim = GameObject.Find("Start_UI").GetComponent<Animator>();
            anim.SetFloat("Speed",1);
            anim.Play("kick");
            _startPannel.SetActive(false);
            _teachPannel = CreateUICanvas(teachPannel);
            _teachPannel.SetActive(true);
        }

        public void CreatChosePannel()
        {
            CreateUICanvas(chosePannel);
        }

        public GameObject CreatWinPannel()
        {
            return CreateUICanvas(winPannel);
        }

        public void PointerEnterStart()
        {
            var anim = GameObject.Find("Start_UI").GetComponent<Animator>();
            anim.SetFloat("Speed",1);
            anim.Play("Start");
        }

        public void PointerExitStart()
        {
            var anim = GameObject.Find("Start_UI").GetComponent<Animator>();
            anim.SetFloat("Speed",-1);
            anim.Play("Start");
        }

        public void OnPlayerConfirm(int playerid)
        {
            Managers.Instance.PlayerConfirm(playerid);
        }

        public void BacktoStart()
        {
            SceneManager.LoadScene("StartScene");
        }

        public void OnTeachingClicked()
        {
            teachPannel.SetActive(false);
            CreatChosePannel();
        }
    }
}