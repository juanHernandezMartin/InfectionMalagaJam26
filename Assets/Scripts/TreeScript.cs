using DG.Tweening;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [HideInInspector]
    public treeManager treeManager;
    public TreeAnimation treeAnimation;
    public int maxWood = 5;
    private float timeToBecomeVisible = 1;
    public GameObject treeMesh;
    
    private int currentWood = 0;

    void Update()
    {
        timeToBecomeVisible -= Time.deltaTime;
        if(timeToBecomeVisible <= 0)
        {
            treeMesh.SetActive(true);
        }
    }

    private void Start()
    {
        currentWood = maxWood;
    }

    public void OnMouseDown()
    {
        treeManager.inventory.woodCount++;
        treeAnimation.StartClickAnimation();
        currentWood--;
        if (currentWood < 0)
        {
            Destroy(gameObject);
            treeManager.currentTrees--;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle") )
        {
            Debug.Log("Tree hit obstacle, respawning");
            treeManager.currentTrees--;
            treeManager.SpawnTrees();
            Destroy(gameObject);
        }
    }
}
