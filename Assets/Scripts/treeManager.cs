using System.Collections.Generic;
using UnityEngine;

public class treeManager : MonoBehaviour
{
    public int maxTrees = 10;
    public GameObject treePrefab;

    private List<GameObject> trees;

    private float elapsedTime;
    public float generationInterval = 3f;

    public float rangeX = 20f;
    public float rangeZ = 20f;

    void Awake()
    {
        trees = new List<GameObject> ();
        elapsedTime = 0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= generationInterval)
        {
            CreateTree();
            elapsedTime = 0;
        }
    }

    void CreateTree()
    {
        if (trees.Count >= maxTrees)
            return ;
            
        Vector3 randomPosition = GetRandomPosition();

        GameObject newTree = Instantiate(treePrefab, randomPosition, Quaternion.identity);

        trees.Add(newTree);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-rangeX, rangeX);
        float z = Random.Range(-rangeZ, rangeZ);
        float y = 0f;

        return new Vector3(x, y, z);
    }

}