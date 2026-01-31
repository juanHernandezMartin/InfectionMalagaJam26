using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public int maxWood = 5;
    private int currentWood = 0;

    private void Start()
    {
        currentWood = maxWood;
    }

    public void OnMouseDown()
    {
        currentWood--;
        if (currentWood < 0)
        {
            Destroy(gameObject);
        }
    }
}
