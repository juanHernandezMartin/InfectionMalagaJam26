using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public FactoryAnimation factoryAnimation;
    public FactoryUI factoryUI;
    public InventoryScript inventory;
    public GameObject factoryModel;
    public GameObject factoryParticles;
    public int maskPrice = 5;
    public int buildPrice = 10;
    public float productionTime = 2.0f;
    public float productionTimer = 0.0f;

    private bool isBuilt = false;
    private UnityEngine.UI.Slider productionSlider;

    public void Start()
    {
        productionSlider = factoryUI.slider.GetComponent<UnityEngine.UI.Slider>();
    }

    public void OnMouseDown()
    {
        if (!isBuilt)
        {
            if (inventory.woodCount >= buildPrice)
            {
                inventory.woodCount -= buildPrice;
                isBuilt = true;
                factoryModel.SetActive(true);
                factoryParticles.SetActive(true);
                factoryAnimation.StartClickAnimation();
                factoryUI.exangeSign.SetActive(true);
                factoryUI.buildinSign.SetActive(false);
            }
            return;
        }

        if (inventory.woodCount >= maskPrice && productionTimer <= 0)
        {
            inventory.woodCount-=maskPrice;
            factoryAnimation.StartClickAnimation();
            factoryUI.slider.SetActive(true);
            factoryUI.exangeSign.SetActive(false);
            productionTimer = productionTime;
        }
    }

    private void Update()
    {
        if (productionTimer > 0)
        {
            productionSlider.value = 1 - (productionTimer / productionTime);
            productionTimer -= Time.deltaTime;
            if (productionTimer <= 0)
            {
                inventory.maskCount++;
                factoryUI.slider.SetActive(false);
                factoryUI.exangeSign.SetActive(true);
            }
        }
    }

}
