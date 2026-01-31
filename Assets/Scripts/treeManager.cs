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


    void RemoveTreeFromList(GameObject tree)
    {
        trees.Remove(tree);
    }

    void CreateTree()
    {
        if (trees.Count >= maxTrees)
            return ;
            
        float radius = 0.4985f;
        Vector3 randomDirection = Random.onUnitSphere;
        Vector3 position = randomDirection * radius;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, randomDirection);

        GameObject newTree = Instantiate(treePrefab, position, rotation, transform);

        Tree treeComponent = newTree.GetComponent<Tree>();

        if (treeComponent == null)
        {
            treeComponent = newTree.AddComponent<Tree>();
        }
        
        treeComponent.OnTreeDestroyed += RemoveTreeFromList;

        trees.Add(newTree);
    }


}