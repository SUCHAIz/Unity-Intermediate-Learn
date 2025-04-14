using UnityEngine;

public class Items : MonoBehaviour , ICollectable
{
    public void Collect()
    {
        //GameManager.Instance._Money = price;
        Debug.Log("Item collected!");
        
        Destroy(gameObject);
    }
}
