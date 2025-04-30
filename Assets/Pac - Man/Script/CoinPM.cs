using UnityEngine;

public class CoinPM : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(1);

            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Destroy(gameObject); // <-- ลบเหรียญออกจากฉาก
        }
    }
}
