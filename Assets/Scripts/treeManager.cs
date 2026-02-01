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
    }

    public void SpawnTrees()
    {
        if (currentTrees >= maxTrees)
            return;
        Vector3 treesPosition = new Vector3(0, 0, 0);
        GameObject newTree = Instantiate(treePrefab, treesPosition, Random.rotation);
        newTree.transform.parent = transform;
        newTree.GetComponent<TreeScript>().treeManager = this;
        currentTrees++;
    }
}