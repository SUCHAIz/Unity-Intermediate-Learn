using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PacManChase : MonoBehaviour
{
    public string targetTag = "Player";
    public float moveSpeed = 5f;
    public GameObject gameOverPanel;

    private Transform target;
    private bool isGameOver = false;

    void Start()
    {
        // หาผู้เล่น
        GameObject player = GameObject.FindGameObjectWithTag(targetTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Check the tag.");
        }

        // ซ่อน UI Game Over ตอนเริ่มเกม
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver || target == null) return;

        // เดินไล่ผู้เล่น
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return;

        // เฉพาะเมื่อชน Player เท่านั้น
        if (other.CompareTag(targetTag))
        {
            isGameOver = true;

            Debug.Log("Pac-Man เดินชน Player -> Game Over!");

            // แสดงหน้าต่าง Game Over
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            // ปิดการควบคุม Player
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;

            // หยุดการเคลื่อนไหว Pac-Man
            enabled = false;

            // หยุดเวลาเกม
            Time.timeScale = 0f;
        }
    }
}
