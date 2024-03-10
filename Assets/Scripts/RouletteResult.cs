using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RouletteResult : MonoBehaviour
{
    public static RouletteResult instance;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GetRouletteResult()
    {

        if (DiceRollUI.Instance.saveRandomNumber > DiceRollUI2.Instance.saveRandomNumber)
        {
            Player.instance.playerDrawSpeed += 80;
            Debug.Log("RuletKazanildi");
    

        }
        else if (DiceRollUI.Instance.saveRandomNumber < DiceRollUI2.Instance.saveRandomNumber)
        {
            StartCoroutine(WaitForLoseScreen());
        }

    }

    IEnumerator WaitForLoseScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

}
