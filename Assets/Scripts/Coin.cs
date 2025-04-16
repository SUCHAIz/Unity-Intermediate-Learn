using UnityEngine;
using DG.Tweening;
public class Coin : MonoBehaviour , ICollectable
{
    [SerializeField] private int price = 5;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float updownSpeed = 1f;
    void PrintCurrentMoney(int currentMoney)
    {
        Debug.Log($"Current money is {currentMoney}");
    }

    private void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney);


        transform.DOMoveY(transform.position.y + 0.25f, 1f)
         .SetLoops(999, LoopType.Yoyo);

    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney);
    }
    public void Collect()
    {
        GameManager.Instance._Money = price;
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        transform.position += Vector3.up * Mathf.Sin(Time.time * updownSpeed) * Time.deltaTime;
    }
    
}
