using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    
    private bool isDuelStarted;
    
    public TextMeshProUGUI countdownText;

    public int dieCount;

    public int level = 1;

    public Animator BlackoutAnim;


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
        
        /*
        // Start the duel when the player preses the space key
        if (Input.GetKeyDown(KeyCode.Space) && !isDuelStarted)
        {
            StartDuel();
        }
        */
        
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
        
        CheckDuelStarted(); // if duel is happening show the duel bar
        
        // Change the line speed and red area size based on the draw speeds of the player and the enemy
        BarSystem.Instance.ChangeLineSpeed(Enemy.instance.enemyDrawSpeed , Player.instance.playerDrawSpeed);
        BarSystem.Instance.ChangeRedAreaSize(Enemy.instance.enemyDrawSpeed , Player.instance.playerDrawSpeed);

        StartCoroutine(BarSystem.Instance.CheckPressedSpace()); // Start the coroutine to check if the player presses space within 5 seconds

    }

    // Check the result of the duel
    public void CheckDuelResult()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !BarSystem.Instance.isDuelWon)
        {
            if (BarSystem.Instance.inRedArea)
            {
                // Win the duel
                BarSystem.Instance.WinDuel();

                BarSystem.Instance.DuelBar.SetActive(false);
                countdownText.gameObject.SetActive(false);

                DuelWonAnimationController.instance.PlayWinAnimation(); // Play the win animation
                BlackoutAnim.SetTrigger("WinCondition");
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

    
    /*
    public IEnumerator CheckPressedSpace()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // If the player hasn't pressed space within 5 seconds, they lose the duel
        if (!BarSystem.Instance.isDuelWon)
        {
            BarSystem.Instance.LoseDuel();
        }
    }
    */
    // Add more methods for duel logic, such as resolving outcomes, determining winners, etc.
}

