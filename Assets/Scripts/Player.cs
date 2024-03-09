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
}
