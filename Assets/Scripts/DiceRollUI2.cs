using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollUI2 : MonoBehaviour
{
    [SerializeField] Sprite[] diceImages;
    [SerializeField] Image imageComponent2; // Reference to the Image component of the second dice game object
    int randomNumber;
    public int saveRandomNumber;

    public static DiceRollUI2 Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //ThrowTheDice();
    }

    public void ThrowTheDice()
    {
        randomNumber = Random.Range(0, diceImages.Length);
        saveRandomNumber = randomNumber + 1;
        imageComponent2.sprite = diceImages[randomNumber];
        Debug.Log("Dice rolled: " + (randomNumber + 1)); // Adjust for 1-based indexing if needed

    }

}
