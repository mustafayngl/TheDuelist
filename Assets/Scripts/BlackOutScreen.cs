using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutScreen : MonoBehaviour
{
    public Animator BlackoutAnim;

    public void CheckLevel()
    {

        if (GameManager.instance.dieCount % 3 == 0)
        {
            GameManager.instance.level = 1;
        }

        if (GameManager.instance.level == 1)
        {
            Debug.Log("level1");
            //TODO
            //tp level1
        }
        else if (GameManager.instance.level == 2)
        {
            Debug.Log("level2");
            //tp level 2
        }
        else if (GameManager.instance.level == 3)
        {
            Debug.Log("level3");
            //tp level 3
        }
        
    }
    public void AnimIdle()
    {
        BlackoutAnim.SetTrigger("ToIdle");
    }


}
