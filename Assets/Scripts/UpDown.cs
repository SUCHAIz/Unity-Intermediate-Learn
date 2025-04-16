using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private float updownSpeed = 1f;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * Mathf.Sin(Time.time * updownSpeed) * Time.deltaTime;
    }
}
