using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // singletons
    public static Enemy instance;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public int enemyDrawSpeed = 80;


    // Take the enemy draw speed and give it to the player if the player wins the duel
    public void TakeDrawSpeed()
    {
        Debug.Log("Enemy draw speed: " + enemyDrawSpeed);

        // TODO: roll a dice and give the draw speed to the player based on the dice result


        // give draw speed to player
        //Player.instance.playerDrawSpeed += enemyDrawSpeed / 2; ////////

        Player.instance.playerDrawSpeed += (int)CalculateDrawSpeed();

        GameManager.instance.dieCount++;

        enemyDrawSpeed = Random.Range(GameManager.instance.dieCount * 20, GameManager.instance.dieCount * 40);

    }

    public float CalculateDrawSpeed()
    {
        int rollResult = Dice.instance.RollDiceWithBetterOdds();
        Debug.Log("Dice Resut : " + rollResult);
        Debug.Log("Draw Speed : " + rollResult * 16 / 100f);
        
        
        //return rollResult * 16 / 100f;
        
        return rollResult * 16 / 2;  ///////
        
    }
}