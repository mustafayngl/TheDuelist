using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    // singletons
    public static Player instance;
    
    public int playerDrawSpeed = 100;
    
    public TextMeshProUGUI playerDrawSpeedText;
    
    
    // for teleport camera to the player
    public Camera mainCamera;
    
    
    
    public Animator PlayerMoveRight;
    public Animation playermove;
    public AnimationClip playermoveclip;
    private void Awake()
    {
        // singleton pattern
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        playerDrawSpeedText.text = playerDrawSpeed.ToString();
    }

    
    
    
    public void TeleportPlayer()
    {
        if (GameManager.instance.level == 1)
        {
            gameObject.transform.position.Set(-6.41f,gameObject.transform.position.y,gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 2)
        {
            gameObject.transform.position.Set(13,gameObject.transform.position.y,gameObject.transform.position.z);
        }
        else if (GameManager.instance.level == 3)
        {
            gameObject.transform.position.Set(32,gameObject.transform.position.y,gameObject.transform.position.z);
        }
       
    }
    
    public void AnimIdle()
    {
        PlayerMoveRight.SetTrigger("ReturnIdle");
        //PlayerMoveRight.StopPlayback();
      
        
    }
    
    public void StopAnimation()
    {
        
        // after 2 second enable the animator
        StartCoroutine(EnableAnimator());
            
    }
    
    
    
    
    IEnumerator EnableAnimator()
    {
        PlayerMoveRight.gameObject.GetComponent<Animator>().enabled = false; // disable the animator after move right
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        
        // if level is 1 enable the animator. animator makes the player tp level 1
        if (GameManager.instance.level == 1)
        {
            // Enable the animator
            PlayerMoveRight.gameObject.GetComponent<Animator>().enabled = true;
        }
        
    }
    
}
