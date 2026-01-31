using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public FactoryAnimation factoryAnimation;
    public InventoryScript inventory;
    private int price = 10;

    public void OnMouseDown()
    {
        if (inventory.woodCount >= price)
        {
            inventory.woodCount-=5;
            inventory.maskCount++;
            factoryAnimation.StartClickAnimation();
        }
    }

}
