using UnityEngine;

public class Tree : MonoBehaviour
{
    public int maxResources = 10;
    
    private int currentResources = 0;

    void Start()
    {
        currentResources = maxResources;
        
        // Añadir collider si no existe
        if (GetComponent<Collider>() == null)
        {
            CapsuleCollider collider = gameObject.AddComponent<CapsuleCollider>();
            collider.radius = 0.5f;
            collider.height = 2f;
        }
    }

    void Update()
    {

    }

    public int HarvestResources(int amount)
    {
        int harvested = Mathf.Min(amount, currentResources);
        currentResources -= harvested;
        if (currentResources <= 0)
        {
            Destroy(gameObject);
        }
        return harvested;
    }

    public int HarvestAllResources()
    {
        int harvested = currentResources;
        currentResources = 0;
        
        if (currentResources <= 0)
        {
            DestroyTree();
        }
        
        return harvested;
    }

    public int GetCurrentResources()
    {
        return currentResources;
    }

    public System.Action<GameObject> OnTreeDestroyed;

    private void DestroyTree()
    {
        OnTreeDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }

}
