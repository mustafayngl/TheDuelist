using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollUI : MonoBehaviour
{
    [SerializeField] Sprite[] diceImages;
    [SerializeField] Image imageComponent;
    int randomNumber;

    void Start()
    {
        ThrowTheDice();
    }

    public void ThrowTheDice()
    {
        randomNumber = Random.Range(0, diceImages.Length);
        imageComponent.sprite = diceImages[randomNumber];
        Debug.Log("Dice rolled: " + (randomNumber + 1)); // Adjust for 1-based indexing if needed
    }
}
