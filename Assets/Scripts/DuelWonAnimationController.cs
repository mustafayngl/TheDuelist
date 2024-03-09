using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelWonAnimationController : MonoBehaviour
{
    public float hizi = 5f; // Karakterin yürüme hızı

    public GameObject player;
    
    public Animator winAnimation;

    private void Awake()
    {
        winAnimation.StopPlayback();
    }

    public void PlayWinAnimation()
    {
        winAnimation.StartPlayback();
        player.GetComponent<Animator>().SetTrigger("Win");

        // Sağa doğru yürümeyi başlatın
        StartCoroutine(YuruSag());
    }

    IEnumerator YuruSag()
    {
        // Karakterin dönüşünü sağa çevirin
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // Bir while döngüsü kullanarak karakteri sağa doğru hareket ettirin
        while (true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * hizi, Space.World);
            yield return null;
        }
    }
}
