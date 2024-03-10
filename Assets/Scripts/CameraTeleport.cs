using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (BarSystem.Instance.isDuelWon)
        {
            StartCoroutine(TeleportCamera());
        }
    }

    IEnumerator TeleportCamera()
    {
        yield return new WaitForSeconds(5);
        if (GameManager.instance.level == 2)
        {
            gameObject.transform.position =
                new Vector3(19, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 3)
        {
            gameObject.transform.position =
                new Vector3(38, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 1)
        {
            gameObject.transform.position =
                new Vector3(-6.41f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}