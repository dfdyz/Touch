using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    [SerializeField]
    private PlayerEntity playerA;
    [SerializeField]
    private PlayerEntity playerB;

    [SerializeField]
    private SpawnPoint spawnPointA;

    [SerializeField]
    private SpawnPoint spawnPointB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {

    }

    void FixedUpdate()
    {
        
    }

    public void RebornPlayer(int player)
    {
        if(player == 1) {
            playerA.ReBorn(spawnPointA.transform.position);
        }
        if(player == 2)
        {
            playerB.ReBorn(spawnPointB.transform.position);
        }


    }

}
