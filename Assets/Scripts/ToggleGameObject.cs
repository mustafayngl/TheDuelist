using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject gameObjectToToggle; // Reference to the GameObject to toggle

    public void ToggleObject()
    {
        // Toggle the active state of the GameObject and all its children
        gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
    }
    public void ToggleObjectWait()
    {
        StartCoroutine(WaitForToggleObject());
        // Toggle the active state of the GameObject and all its children
      
    }

    IEnumerator WaitForToggleObject()
    {
        yield return new WaitForSeconds(2f);
        gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
        ToggleAnimation.instance.animator1.enabled = true;
        ToggleAnimation.instance.animator2.enabled = true;
    }

}

