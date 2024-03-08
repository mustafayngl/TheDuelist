using UnityEngine;

public class BarSystem : MonoBehaviour
{
    public Transform line; // Çizgi objesinin referansı
    public Transform bar; // Bar objesinin referansı
    public GameObject redArea; // Kırmızı alan objesinin referansı

    private bool inRedArea; // Çizgi kırmızı alanda mı?
    private bool gameWon; // Oyun kazanıldı mı?

    void Start()
    {
        inRedArea = false;
        gameWon = false;
    }

    void Update()
    {
        // Çizginin hareketini sağlayan kod
        MoveLine();

        // Space tuşuna basıldığında ve çizgi kırmızı alanda ise kazanma kontrolü yapılır
        if (Input.GetKeyDown(KeyCode.Space) && inRedArea && !gameWon)
        {
            WinGame();
        }
    }
    
    /*
    // old 
    void MoveLine()
    {
        // Çizgiyi sağa ve sola hareket ettiren kod
        float moveSpeed = 3f; // Çizgi hareket hızı
        float moveDirection = Mathf.Sin(Time.time); // Sine dalga formuyla hareket
        float newX = Mathf.Lerp(-4f, 4f, (moveDirection + 1f) / 2f); // -4 ile 4 arasında değer üret
        line.position = new Vector3(newX, line.position.y, line.position.z);
    }
    */
    
    void MoveLine()
    {
        // Çizgiyi sağa ve sola hareket ettiren kod
        float moveSpeed = 3f; // Çizgi hareket hızı
        float moveDirection = Mathf.Sin(Time.time); // Sine dalga formuyla hareket

        // Calculate the left and right bounds based on the bar's position and scale
        float barWidth = bar.localScale.x;
        float leftBound = bar.position.x - barWidth / 2;
        float rightBound = bar.position.x + barWidth / 2;

        // Calculate the new X position within the bounds
        float newX = Mathf.Lerp(leftBound, rightBound, (moveDirection + 1f) / 2f);

        line.position = new Vector3(newX, line.position.y, line.position.z);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Çizgi kırmızı alana girdiğinde tetiklenen kod
        if (other.gameObject == redArea)
        {
            inRedArea = true;
            Debug.Log("Kırmızı alana girdiniz!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Çizgi kırmızı alandan çıktığında tetiklenen kod
        if (other.gameObject == redArea)
        {
            inRedArea = false;
        }
    }

    void WinGame()
    {
        // Oyun kazanıldığında tetiklenen kod
        Debug.Log("Kazandınız!");
        gameWon = true;
        // İstediğiniz diğer işlemleri yapabilirsiniz, örneğin kazanma ekranı göstermek veya oyunu yeniden başlatmak
    }
}