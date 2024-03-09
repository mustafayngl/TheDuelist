using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public BarSystem barSystem;

    private bool isDuelStarted;

    void Start()
    {
        isDuelStarted = false;
    }

    void Update()
    {
        
        /*
        // Start the duel when the player presses the space key
        if (Input.GetKeyDown(KeyCode.Space) && !isDuelStarted)
        {
            StartDuel();
        }
        */
        
        CheckDuelResult();
    }

    public void StartDuel()
    {
        // Set duel started flag to true
        isDuelStarted = true;
        
        // Determine duel outcome based on the player's input timing within the bar system

        // BU SATIRI BEN YOORUM SATIRINA ALDIM COMPOILE EROR VERIYORDU DENYEMIYORDUM -SADIK   bool playerWins = barSystem.PlayerAttack();//bunlari ekleyince ismi degistirirsin

        // If the player wins, acquire a portion of the enemy's draw speed for the next level

        // BU SATIRI BEN YOORUM SATIRINA ALDIM COMPOILE EROR VERIYORDU DENYEMIYORDUM -SADIK  if(playerWins)
        {
            // Acquire a portion of the enemy's draw speed based on the result
            // BU SATIRI BEN YOORUM SATIRINA ALDIM COMPOILE EROR VERIYORDU DENYEMIYORDUM -SADIK float acquiredDrawSpeed = barSystem.GetEnemyDrawSpeedAcquired();//bunlari ekleyince ismi degistirirsin
            // Store acquired draw speed for next level or use it immediately as needed
        }

        // Start the duel (implement duel logic here)
        // You might want to trigger animations, sound effects, etc.


        // Change the line speed and red area size based on the draw speeds of the player and the enemy
        BarSystem.Instance.ChangeLineSpeed(Enemy.instance.enemyDrawSpeed , Player.instance.playerDrawSpeed);
        BarSystem.Instance.ChangeRedAreaSize(Enemy.instance.enemyDrawSpeed , Player.instance.playerDrawSpeed);
        
        
        
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
    
    // Add more methods for duel logic, such as resolving outcomes, determining winners, etc.
}

