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
    public float currentProgress = 0.0f;

    public bool isEnabled;

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
            currentProgress = investigationTime;
            percentage.SetActive(true);
            isEnabled = true;

        }
    }

    private void Update()
    {
        if (isEnabled)
        {
            progressSlider.value = 1 - (currentProgress / investigationTime);
            per = progressSlider.value * 100;
            percentage.GetComponent<TextMeshProUGUI>().text = per.ToString("0.0") + "%";
            currentProgress -= Time.deltaTime;

            if (currentProgress <= 0  && inventory.healthyCount >= 10)
            {
                winUI.SetActive(true);
            }
        }
       
    }
}

