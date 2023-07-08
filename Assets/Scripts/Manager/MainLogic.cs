using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    [Header("Reborn")]
    [SerializeField] 
    private float rebornTime;
    [SerializeField]
    private PlayerEntity playerA;
    [SerializeField]
    private PlayerEntity playerB;

    [SerializeField]
    private Transform spawnPointA;

    [SerializeField]
    private Transform spawnPointB;

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
        print($"player die : " + playerID);
        StartCoroutine(playerWin(playerID));
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
        yield return new WaitForSeconds(0f);
        RebornPlayer(1);
        RebornPlayer(2);

    }

    private IEnumerator playerWin(int deadPlayer)
    {
        var waitTime = new WaitForSeconds(2f);
        if (deadPlayer == 2)
        {
            playerA.isWinning = true;
            yield return waitTime;
            RebornPlayer(2);
            playerA.isWinning = false;
        }
        else if(deadPlayer == 1)
        {
            playerB.isWinning = true;
            yield return waitTime;
            RebornPlayer(1);
            playerB.isWinning = false;
            print("player2 win over");
        }
    }
}
