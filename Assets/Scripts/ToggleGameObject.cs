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
}

