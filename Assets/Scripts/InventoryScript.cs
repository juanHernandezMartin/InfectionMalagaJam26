using TMPro;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int woodCount = 0;
    public int infectedCount = 0;
    public int healthyCount = 0;
    public int maskCount = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI infectedText;
    public TextMeshProUGUI healthyText;
    public TextMeshProUGUI maskText;

    public void Update()
    {
        infectedText.text = "Infected: " + infectedCount;
        healthyText.text = "Healthy: " + healthyCount;
        woodText.text = woodCount.ToString();
        maskText.text = maskCount.ToString();
    }
}