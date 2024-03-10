using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtons : MonoBehaviour
{
    // Singleton instance
    
    public static HideButtons instance;
    
    
    
    
    public GameObject rouletteButton;
    public GameObject duelButton;


    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HideButtonsFunction()
    {
        rouletteButton.SetActive(false);
        duelButton.SetActive(false);
    }
    
    public void ShowButtonsFunction()
    {
        rouletteButton.SetActive(true);
        duelButton.SetActive(true);
    }

    public IEnumerator HideWaitAndShowButtons()
    {
        HideButtonsFunction();
        yield return new WaitForSeconds(5f);
        ShowButtonsFunction();
    }
    
}
