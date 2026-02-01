using System.Collections.Generic;
using UnityEngine;

public class FactoryImprovement : MonoBehaviour
{
    public int improvementCost = 60;
    public InventoryScript inventory;
    public List<FactoryScript> factoriesToImprove;

    public void ImproveFactories()
    {
        if( inventory.woodCount < improvementCost )
            return;

        inventory.woodCount -= improvementCost;
        Debug.Log("Improving factories!");
        foreach( FactoryScript factory in factoriesToImprove )
        {
            factory.productionTime = 3f;
        }

        Destroy(gameObject);
    }
}
