using System.Collections.Generic;
using UnityEngine;

public class treeManager : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject treePrefab;
    public float timeToSpawn = 1.0f;
    public int startingTrees = 4;
    public int maxTrees = 20;
    private int initialMaxTrees;

    [HideInInspector]
    public int currentTrees = 0;
    public bool improvedWood = false;
    public GameObject improveWoodButton;

    void Start()
    {
        for (int i = 0; i < startingTrees; i++)
        {
            SpawnTrees();
        }
        initialMaxTrees = maxTrees;
        InvokeRepeating(nameof(SpawnTrees), timeToSpawn, timeToSpawn);
    }

    void Update()
    {
        maxTrees = initialMaxTrees + inventory.healthyCount;
        if(inventory.healthyCount >= 8 && !improvedWood)
        {
            ShowImprovingButton();
        }
    }

    public void SpawnTrees()
    {
        if (currentTrees >= maxTrees)
            return;
        Vector3 treesPosition = new Vector3(0, 0, 0);
        GameObject newTree = Instantiate(treePrefab, treesPosition, Random.rotation);
        newTree.transform.parent = transform;
        newTree.GetComponent<TreeScript>().treeManager = this;
        if (improvedWood)
        {
            newTree.GetComponent<TreeScript>().improvedWood = true;
        }
        currentTrees++;
    }

    public void ShowImprovingButton()
    {
        improveWoodButton.SetActive(true);
    }

    public void ImproveWood(int price)
    {
        if(inventory.woodCount >= price)
        {
            inventory.woodCount-= price;
            improvedWood = true;
            improveWoodButton.SetActive(false);
        }
    }
}