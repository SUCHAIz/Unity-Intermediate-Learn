using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class PacManChase : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject gameOverPanel;
    public AudioClip gameOverSound; // 🎵 เพิ่มตรงนี้

    private Transform target;
    private NavMeshAgent agent;
    private bool isGameOver = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindGameObjectWithTag(targetTag);
        if (player != null)
            target = player.transform;
        else
            Debug.LogWarning("Player not found. Check the tag.");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver || target == null) return;

        agent.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return;

        if (other.CompareTag(targetTag))
        {
            isGameOver = true;
            Debug.Log("Pac-Man ชน Player -> Game Over!");

            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            // 🔊 เล่นเสียง Game Over
            if (gameOverSound != null)
                AudioSource.PlayClipAtPoint(gameOverSound, transform.position);

            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;

            agent.isStopped = true;
            Time.timeScale = 0f;
        }
    }
}
