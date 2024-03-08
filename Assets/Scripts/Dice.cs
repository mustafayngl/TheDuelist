using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
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
