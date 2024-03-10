using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// it is responsible for the win animation of the player (move right animation)
public class DuelWonAnimationController : MonoBehaviour
{
    // Singleton
    public static DuelWonAnimationController instance;


    public float hizi = 5f; // Karakterin yürüme hızı

    public GameObject player;

    public Animator winAnimation;

    private void Awake()
    {
        //winAnimation.StopPlayback();

        // singleton pattern
        if (instance == null)
        {
            instance = this;
        }
    }
    
    
    // player win animation based on level. before the playing the animation, enable the animator
    public void PlayWinAnimation()
    {
        if (GameManager.instance.level == 2)
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().SetTrigger("WinLevel2");
        }
        else if (GameManager.instance.level == 3)
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().SetTrigger("WinLevel3");
        }
        else if (GameManager.instance.level == 1 )
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().SetTrigger("Win");
        }


    }


    
}