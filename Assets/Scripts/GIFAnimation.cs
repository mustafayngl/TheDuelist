using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GIFAnimation : MonoBehaviour
{
    public Texture2D[] frames;
    public float frameRate = 0.1f;
    private int currentFrame = 0;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            rawImage.texture = frames[currentFrame];
            yield return new WaitForSeconds(frameRate);
            currentFrame = (currentFrame + 1) % frames.Length;
        }
    }
}
