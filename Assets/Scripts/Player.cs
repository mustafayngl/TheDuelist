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
}
