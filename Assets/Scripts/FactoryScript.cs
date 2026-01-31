using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public InventoryScript inventory;

    public void OnMouseDown()
    {
        if (inventory.woodCount > 0)
        {
            inventory.woodCount--;
            inventory.maskCount++;
        }
    }

}
