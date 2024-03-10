using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{

    public Animator animator1; // Reference to the Animator component of object 1
    public GameObject animationObject1; // Reference to the GameObject containing the animation for object 1

    public Animator animator2; // Reference to the Animator component of object 2
    public GameObject animationObject2; // Reference to the GameObject containing the animation for object 2

    public static ToggleAnimation instance;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ToggleAnimationAndVisibility()
    {
        //// Toggle the Animator component and visibility for object 1
        //animator1.enabled = !animator1.enabled;
        //animationObject1.SetActive(!animationObject1.activeSelf);

        //// Toggle the Animator component and visibility for object 2
        //animator2.enabled = !animator2.enabled;
        //animationObject2.SetActive(!animationObject2.activeSelf);


        animator1.enabled = false;
        animationObject1.SetActive(!animationObject1.activeSelf);

        // Toggle the Animator component and visibility for object 2
        animator2.enabled = false;
        animationObject2.SetActive(!animationObject2.activeSelf);
    }
}
