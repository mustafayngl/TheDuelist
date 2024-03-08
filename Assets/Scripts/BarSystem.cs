using UnityEngine;

public class BarSystem : MonoBehaviour
{
    public Transform line; // Çizgi objesinin referansı
    public Transform bar; // Bar objesinin referansı
    public GameObject redArea; // Kırmızı alan objesinin referansı

    private bool inRedArea; // Çizgi kırmızı alanda mı?
    private bool gameWon; // Oyun kazanıldı mı?
    
    
    // Draw Speeds
    public int playerDrawSpeed = 100;
    public int enemyDrawSpeed = 40;



    public void ChangeRedAreaSize(int enemyDrawSpeed, int playerDrawSpeed)
    {
        // Kırmızı alanın boyutunu değiştiren kod
        //redArea.transform.localScale = new Vector3(enemyDrawSpeed / playerDrawSpeed, 1, 1);
        redArea.transform.localScale = new Vector3(bar.localScale.x/Mathf.Abs(enemyDrawSpeed - playerDrawSpeed), 1, 1);
        
        redArea.transform.localScale = new Vector3(bar.localScale.x/(enemyDrawSpeed - playerDrawSpeed), 1, 1);

        
        
    }
    
    
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
        
        
        // when X is pressed, change the size of the red area based on the enemy and player's draw speeds
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeRedAreaSize(enemyDrawSpeed,playerDrawSpeed);
        }
    }
    
    
    
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
        
    }
}