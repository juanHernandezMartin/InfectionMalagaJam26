using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public FactoryAnimation factoryAnimation;
    public InventoryScript inventory;
    public GameObject factoryModel;
    public GameObject factoryParticles;
    public int maskPrice = 5;
    private int buildPrice = 50;

    private bool isBuilt = false;

    public void OnMouseDown()
    {
        if( !isBuilt )
        {
            if (inventory.woodCount >= buildPrice)
            {
                inventory.woodCount-=buildPrice;
                isBuilt = true;
                factoryModel.SetActive(true);
                factoryParticles.SetActive(true);
                factoryAnimation.StartClickAnimation();
            }
            return;
        }

        if (inventory.woodCount >= maskPrice)
        {
            inventory.woodCount-=maskPrice;
            inventory.maskCount++;
            factoryAnimation.StartClickAnimation();
        }
    }

}
