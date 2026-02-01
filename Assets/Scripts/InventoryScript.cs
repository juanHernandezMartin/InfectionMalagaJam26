using TMPro;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject factoryImprovementUI;
    public int woodCount = 0;
    public int infectedCount = 0;
    public int healthyCount = 0;
    public int maskCount = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI infectedText;
    public TextMeshProUGUI healthyText;
    public TextMeshProUGUI maskText;

    public bool improvedFactory = false;

    public void Update()
    {
        infectedText.text = infectedCount.ToString();
        healthyText.text = healthyCount.ToString();
        woodText.text = woodCount.ToString();
        maskText.text = maskCount.ToString();

        if( woodCount > 40 && !improvedFactory )
        {
            improvedFactory = true;
            factoryImprovementUI.SetActive(true);
        }
    }
}