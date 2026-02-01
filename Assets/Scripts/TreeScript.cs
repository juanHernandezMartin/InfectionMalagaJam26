using DG.Tweening;
using TMPro;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public TextMeshProUGUI woodUI;
    public GameObject woodPlusOneUI;
    public float woodAnimationTime = 0.1f;
    public float woodJumpPower = 0.1f;
    [HideInInspector]
    public treeManager treeManager;
    public TreeAnimation treeAnimation;
    public int maxWood = 5;
    private float timeToBecomeVisible = 0.1f;
    public GameObject treeMesh;
    public bool improvedWood = false;
    
    private int currentWood = 0;
    private Vector3 initialUIPosition;

    void Update()
    {
        timeToBecomeVisible -= Time.deltaTime;
        if (timeToBecomeVisible <= 0)
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
        if( improvedWood )
        {
            woodUI.text = "+2";
        }
        
        initialUIPosition = woodPlusOneUI.transform.localPosition;
        treeManager.inventory.woodCount++;
        if (improvedWood)
        {
           treeManager.inventory.woodCount++;
        }

        treeAnimation.StartClickAnimation();
        currentWood--;
        woodPlusOneUI.SetActive(true);
        woodPlusOneUI.transform.DOLocalMoveZ( woodJumpPower, woodAnimationTime ).OnComplete(() =>
        {
            woodPlusOneUI.SetActive(false);
            if (currentWood < 0)
            {
                Destroy(gameObject);
                treeManager.currentTrees--;
            }
            woodPlusOneUI.transform.localPosition = initialUIPosition;
        });
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Tree hit obstacle, respawning");
            treeManager.currentTrees--;
            treeManager.SpawnTrees();
            Destroy(gameObject);
        }
    }
}
