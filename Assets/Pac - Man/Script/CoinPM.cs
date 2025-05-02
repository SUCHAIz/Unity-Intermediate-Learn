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

            // แจ้ง CoinCollector ว่าเก็บแล้ว
            CoinCollector collector = other.GetComponent<CoinCollector>();
            if (collector != null)
                collector.AddCoin();

            Destroy(gameObject);
            Debug.Log($"เก็บเหรียญ: {other.name} ที่ตำแหน่ง: {other.transform.position}");
        }
    }
}
