using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// it is responsible for teleporting the camera to the next level

public class CameraTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // duello kazanilirsa calistir
        if (BarSystem.Instance.isDuelWon)
        {
            StartCoroutine(TeleportCamera());
        }
    }


    // kamerayi 5 saniye sonra teleport et (5sn yurume animasyonu icin)
    IEnumerator TeleportCamera()
    {
        //yield return new WaitForSeconds(5);
        if (GameManager.instance.level == 2)
        {
            yield return new WaitForSeconds(5);
            gameObject.transform.position = new Vector3(19, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 3)
        {
            yield return new WaitForSeconds(5);
            gameObject.transform.position = new Vector3(38, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 1)
        {
            //yield return new WaitForSeconds(3);
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}