using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{   
    // Singleton
    public static Dice instance;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
    }

    public int RollDiceWithBetterOdds()
    {
        int randomNumber = Random.Range(1, 101);
        if (randomNumber <= 30) // 30% sansla daha iyi zar
        {
            return Random.Range(4, 7); // daha sansli zarlar 4,5,6
        }
        else
        {
            return Random.Range(1, 4); // daha sanssiz zarlar 1,2,3
        }
    }
}
