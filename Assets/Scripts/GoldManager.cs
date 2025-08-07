
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;

    public int currentGold = 0;
    public Text goldText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (goldText != null)
        {
            goldText.text = currentGold.ToString();
        }
    }
}
