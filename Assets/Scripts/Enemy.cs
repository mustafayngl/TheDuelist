using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

       
        // give draw speed to player
        Player.instance.playerDrawSpeed += enemyDrawSpeed / 2;
    }
}
