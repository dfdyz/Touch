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

    private int deathCountA = 0;
    private int deathCountB = 0;


    

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
        StartCoroutine(playerWin(playerID));
    }
    

    public void RebornPlayer(int player)
    {
        if(player == 1) {
            playerA.ReBorn(spawnPointA.transform.position);
        }
        else if(player == 2)
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
        if(deadPlayer == 1) {
            deathCountA++;
        }
        else
        {
            deathCountB++;
        }

        if (deathCountA >= 3 || deathCountB >= 3)
        {
            OnGameOver(deathCountA < deathCountB ? 1:2);
            yield return null;
        }
        else  {
            var waitTime = new WaitForSeconds(2f);
            if (deadPlayer == 2)
            {
                playerA.isWinning = true;
                yield return waitTime;
                RebornPlayer(2);
                playerA.isWinning = false;
            }
            else if (deadPlayer == 1)
            {
                playerB.isWinning = true;
                yield return waitTime;
                RebornPlayer(1);
                playerB.isWinning = false;

            }
        }
        
    }

    private void OnGameOver(int winPlayer)
    {
        PlayerEntity player = winPlayer == 1 ? playerA : playerB;
        player.isWinning = true;
        print("Player" + winPlayer + " Win");

        //todo




    }





}
