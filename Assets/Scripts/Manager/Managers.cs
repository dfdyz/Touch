using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public MultiCameraMgr MultiCameraMgr;
    public MainLogic LogicMgr;

    public float dmgArg = 10;
    public static float addSpeed_1;
    public static float addSpeed_2;
    public static float addMass_1;
    public static float addMass_2;
    private bool confirm_1;
    private bool confirm_2;
    
    public static class GameLayers
    {
        public static int Player;
        public static int World;
        public static int Entity;
        public static void Init()
        {
            GameLayers.Player = LayerMask.NameToLayer("Player");
            GameLayers.World = LayerMask.NameToLayer("World");
            GameLayers.Entity = LayerMask.NameToLayer("Entity");
            
        }

    }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameLayers.Init();
    }

    public void PlayerConfirm(int playerid)
    {
        if (playerid == 1)
        {
            confirm_1 = true;
        }

        if (playerid == 2)
        {
            confirm_2 = true;
        }

        if (confirm_1 && confirm_2) SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
