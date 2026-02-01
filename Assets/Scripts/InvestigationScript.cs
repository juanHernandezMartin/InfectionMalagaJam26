using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestigationScript : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject investigationModel;
    public GameObject buildingUI;
    public GameObject progressUI;
    public UnityEngine.UI.Slider progressSlider;

    public int buildPrice = 10;

    public float investigationTime = 10.0f;
    public float investigationTimer = 0.0f;

    private bool isBuilt = false;

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
        }
    }

    private void Update()
    {
        if (investigationTimer > 0)
        {
            progressSlider.value = 1 - (investigationTimer / investigationTime);
            investigationTimer -= Time.deltaTime;
            if (investigationTimer <= 0)
            {
                //reload secene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

