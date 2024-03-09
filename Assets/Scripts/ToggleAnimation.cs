using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public GameObject animationObject; // Reference to the GameObject containing the animation

    public void ToggleAnimationAndVisibility()
    {
        // Toggle the Animator component
        animator.enabled = !animator.enabled;

        // Toggle the visibility of the GameObject
        animationObject.SetActive(!animationObject.activeSelf);
    }
}
