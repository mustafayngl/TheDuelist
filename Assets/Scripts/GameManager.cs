using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    private bool isDuelStarted;

    public TextMeshProUGUI countdownText;

    public int dieCount;

    public int level = 1;

    public Animator BlackoutAnim;

    public AudioSource PlayerAudio;

    public AudioClip GunVoiceClip;


    // Enemy's
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;


    public int enemyDrawSpeed = 40;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        countdownText.gameObject.SetActive(false); // Hide the countdown text at the start
        isDuelStarted = false;
        BarSystem.Instance.DuelBar.SetActive(false);
    }

    void Update()
    {
        if (level == 1)
        {
            enemyDrawSpeed = Enemy1.GetComponent<Enemy>().enemyDrawSpeed;
        }
        else if (level == 2)
        {
            enemyDrawSpeed = Enemy2.GetComponent<Enemy>().enemyDrawSpeed;
        }
        else if (level == 3)
        {
            enemyDrawSpeed = Enemy3.GetComponent<Enemy>().enemyDrawSpeed;
        }


        CheckDuelResult();
    }

    public void CheckDuelStarted()
    {
        if (!isDuelStarted) return;
        BarSystem.Instance.DuelBar.SetActive(true); // if duel is happening Start the duel bar
        countdownText.gameObject.SetActive(true); // if duel is happening Start the countdown text
    }

    public void StartDuel()
    {
        // Set duel started flag to true
        isDuelStarted = true;
        Debug.Log("Enemy draw speed: " + enemyDrawSpeed);
        CheckDuelStarted(); // if duel is happening show the duel bar

        // Change the line speed and red area size based on the draw speeds of the player and the enemy
        BarSystem.Instance.ChangeLineSpeed(enemyDrawSpeed, Player.instance.playerDrawSpeed);
        BarSystem.Instance.ChangeRedAreaSize(enemyDrawSpeed, Player.instance.playerDrawSpeed);

        StartCoroutine(BarSystem.Instance
            .CheckPressedSpace()); // Start the coroutine to check if the player presses space within 5 seconds

        BarSystem.Instance.isDuelWon = false; // Set the duel won flag to false
    }

    // Check the result of the duel
    public void CheckDuelResult()
    {
        // (Input.GetKeyDown(KeyCode.Space) && !BarSystem.Instance.isDuelWon)
        if (Input.GetKeyDown(KeyCode.Space) && !BarSystem.Instance.isDuelWon)
        {
            if (BarSystem.Instance.inRedArea)
            {
                PlayerAudio.PlayOneShot(GunVoiceClip);

                // Win the duel
                dieCount++;
                
                //HideButtons.instance.HideButtonsFunction();

                StartCoroutine(HideButtons.instance.HideWaitAndShowButtons());
                
                BarSystem.Instance.WinDuel();
                
                
                
                
                
                // Increase the enemy draw speed randomly
                if (GameManager.instance.level == 1)
                {
                    Enemy1.GetComponent<SpriteRenderer>().enabled = false;
                    GameManager.instance.Enemy2.GetComponent<Enemy>().enemyDrawSpeed =
                        Random.Range(GameManager.instance.dieCount * 20, GameManager.instance.dieCount * 33);
                    Enemy2.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (GameManager.instance.level == 2)
                {
                    Enemy2.GetComponent<SpriteRenderer>().enabled = false;
                    //Random.Range(GameManager.instance.dieCount * 20, GameManager.instance.dieCount * 40);
                    GameManager.instance.Enemy3.GetComponent<Enemy>().enemyDrawSpeed =
                        Random.Range(GameManager.instance.dieCount * 20, GameManager.instance.dieCount * 33);
                    Enemy3.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (GameManager.instance.level == 3)
                {
                    Enemy3.GetComponent<SpriteRenderer>().enabled = false;
                    GameManager.instance.Enemy1.GetComponent<Enemy>().enemyDrawSpeed =
                        Random.Range(GameManager.instance.dieCount * 20, GameManager.instance.dieCount * 33);
                    Enemy1.GetComponent<SpriteRenderer>().enabled = true;
                }

                BarSystem.Instance.DuelBar.SetActive(false);
                countdownText.gameObject.SetActive(false);

                DuelWonAnimationController.instance.PlayWinAnimation(); // Play the win animation
                BlackoutAnim.SetTrigger("WinCondition");

                //StartCoroutine(WaitSome());

                level++;


                // Take some of the enemy's draw speed and give it to the player 
                Enemy.instance.TakeDrawSpeed();
            }
            else
            {
                // Lose the duel
                BarSystem.Instance.LoseDuel();
            }
        }
    }
}


/*

// it is doing nothing for now
public IEnumerator WaitSome(float waitTime = 5f)
{
    yield return new WaitForSeconds(waitTime);
}

*/




