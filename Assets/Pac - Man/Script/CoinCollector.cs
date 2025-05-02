using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int totalCoinsToCollect = 16;
    public Text coinText;
    public GameObject winPanel;
    public AudioClip winSound; // 🎵 เพิ่มตรงนี้

    private int coinsCollected = 0;

    void Start()
    {
        totalCoinsToCollect = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCoinText();
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void AddCoin()
    {
        coinsCollected++;
        UpdateCoinText();

        if (coinsCollected >= totalCoinsToCollect)
        {
            Debug.Log("Win! เก็บเหรียญครบแล้ว");
            if (winPanel != null)
                winPanel.SetActive(true);

            // 🔊 เล่นเสียง Win
            if (winSound != null)
                AudioSource.PlayClipAtPoint(winSound, transform.position);

            PlayerController controller = GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = $"Coins: {coinsCollected}/{totalCoinsToCollect}";
    }
}
