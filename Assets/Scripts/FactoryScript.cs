using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public FactoryAnimation factoryAnimation;
    public FactoryUI factoryUI;
    public InventoryScript inventory;
    public GameObject factoryModel;
    public GameObject factoryParticles;
    public int maskPrice = 5;
    public int buildPrice = 30;
    public float productionTime = 10.0f;
    public float productionTimer = 0.0f;
    [SerializeField]
    private bool isBuilt = false;
    private UnityEngine.UI.Slider productionSlider;

    public void Start()
    {
        productionSlider = factoryUI.slider.GetComponent<UnityEngine.UI.Slider>();
        if(isBuilt)
        {
            UnlockFactory(true);
        }
    }

    public void OnMouseDown()
    {
        if (!isBuilt)
        {
            if (inventory.woodCount >= buildPrice)
            {
                UnlockFactory();
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

    public void UnlockFactory(bool isFree = false)
    {
        if(!isFree)
        {
            inventory.woodCount -= buildPrice;
        }
        isBuilt = true;
        factoryModel.SetActive(true);
        factoryParticles.SetActive(true);
        factoryAnimation.StartClickAnimation();
        factoryUI.exangeSign.SetActive(true);
        factoryUI.buildinSign.SetActive(false);
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
