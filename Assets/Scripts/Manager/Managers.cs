using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public MultiCameraMgr MultiCameraMgr;
    public MainLogic LogicMgr;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
