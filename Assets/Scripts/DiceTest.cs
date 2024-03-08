using UnityEngine;

public class DiceTest : MonoBehaviour
{
    public Dice diceRoller;

    void Start()
    {
        Debug.Log("Dice rolled with better odds: " + diceRoller.RollDiceWithBetterOdds());
        Debug.Log("Dice rolled with better odds: " + diceRoller.RollDiceWithBetterOdds());
        Debug.Log("Dice rolled with better odds: " + diceRoller.RollDiceWithBetterOdds());
        Debug.Log("Dice rolled with better odds: " + diceRoller.RollDiceWithBetterOdds());
        Debug.Log("Dice rolled with better odds: " + diceRoller.RollDiceWithBetterOdds());
    }

    void Update()
    {

    }
}
