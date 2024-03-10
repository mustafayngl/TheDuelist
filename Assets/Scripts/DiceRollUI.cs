using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollUI : MonoBehaviour
{
    [SerializeField] Sprite[] diceImages;
    [SerializeField] Image imageComponent;
    int randomNumber;
    public int saveRandomNumber;

    public static DiceRollUI Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
    }

    public void ThrowTheDice()
    {
        randomNumber = Random.Range(0, diceImages.Length);
        saveRandomNumber = randomNumber + 1;
        imageComponent.sprite = diceImages[randomNumber];
        Debug.Log("Dice rolled: " + (randomNumber + 1)); // Adjust for 1-based indexing if needed
    }
}
