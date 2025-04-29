using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // สมมุติว่า Player มีฟังก์ชันรับความเสียหาย
            collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Enemy")) // ไม่ชนศัตรูตัวอื่น
        {
            Destroy(gameObject);
        }
    }
}
