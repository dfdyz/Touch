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

    [Header("Listen to")] 
    [SerializeField] 
    private IntEventChannelSO playerDieEvent;


    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        StartCoroutine(gameStart());

        playerDieEvent.OnEventRaised += OnPlayerDieRaised;
    }

    private void OnPlayerDieRaised(int playerID)
    {
        RebornPlayer(playerID);
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

    private IEnumerator gameStart() {
        yield return new WaitForSeconds(1.5f);
        RebornPlayer(1);
    }
}
