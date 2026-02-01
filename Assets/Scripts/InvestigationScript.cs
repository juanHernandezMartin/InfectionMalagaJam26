using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class InvestigationScript : MonoBehaviour
{
    public GameObject winUI;
    public InventoryScript inventory;
    public GameObject investigationModel;
    public GameObject buildingUI;
    public GameObject progressUI;
    public UnityEngine.UI.Slider progressSlider;
    public GameObject percentage;

    public int buildPrice = 10;

    public float investigationTime = 10.0f;
    public float investigationTimer = 0.0f;

    private bool isBuilt = false;
    private float per;

    public void OnMouseDown()
    {
        if (!isBuilt && inventory.woodCount >= buildPrice)
        {
            inventory.woodCount -= buildPrice;
            isBuilt = true;
            investigationModel.SetActive(true);
            buildingUI.SetActive(false);
            progressUI.SetActive(true);
            investigationTimer = investigationTime;
            percentage.SetActive(true);

        }
    }

    private void Update()
    {
        if (investigationTimer > 0)
        {
            progressSlider.value = 1 - (investigationTimer / investigationTime);
            per = progressSlider.value * 100;
            percentage.GetComponent<TextMeshProUGUI>().text = per.ToString("0.0") + "%";
            investigationTimer -= Time.deltaTime;
            if (investigationTimer <= 0)
            {
                winUI.SetActive(true);
            }
        }
    }
}

