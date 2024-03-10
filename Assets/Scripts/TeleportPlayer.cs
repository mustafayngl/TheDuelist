using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// it is responsible for teleporting the player to the next level after winning the duel

public class TeleportPlayer : MonoBehaviour
{
    void Update()
    {
        // duello kazanilirsa calistir
        if (BarSystem.Instance.isDuelWon)
        {
            StartCoroutine(TPPlayer());
        }
    }


    // kamerayi 5 saniye sonra teleport et (5sn yurume animasyonu icin)
    IEnumerator TPPlayer()
    {
        //yield return new WaitForSeconds(5);
        if (GameManager.instance.level == 2)
        {
            //Player.instance.PlayerMoveRight.gameObject.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(5);
            //HideButtons.instance.ShowButtonsFunction();
            gameObject.transform.position = new Vector3(13, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 3)
        {
            yield return new WaitForSeconds(5);
            //HideButtons.instance.ShowButtonsFunction();
            gameObject.transform.position = new Vector3(31, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 1)
        {
            //HideButtons.instance.ShowButtonsFunction();
            //yield return new WaitForSeconds(3);
            gameObject.transform.position = new Vector3(-4.79f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}