using UnityEngine;

public class HumanInfection : MonoBehaviour
{
    public Material infectedMaterial;
    public Renderer humanRenderer;
    public float maskDuration = 10f;

    [HideInInspector]
    public NPCManager npcManager;
    public GameObject maskObject;
    
    public bool isInfected = false;
    private bool isMasked = false;
    private float maskDurationTimer = 0f;

    public float healthDuration = 20;

    public void Infect()
    {
        if (isInfected || isMasked)
            return;
        isInfected = true;
        npcManager.inventory.healthyCount--;
        npcManager.inventory.infectedCount++;
        humanRenderer.material = infectedMaterial;
    }

    public void Update()
    {
        if (healthDuration <= 0)
        {
            npcManager.currentHumans--;
            npcManager.inventory.infectedCount--;
            Destroy(gameObject);
        }

        if (isInfected)
        {
            healthDuration -= Time.deltaTime;
        }

        if (isMasked)
        {
            maskDurationTimer -= Time.deltaTime;
            if (maskDurationTimer <= 0)
            {
                isMasked = false;
                maskObject.SetActive(false);
            }
        }
    }

    public void OnMouseDown()
    {
        if( npcManager.inventory.maskCount <= 0 )
            return;
        isMasked = true;
        maskDurationTimer = maskDuration;
        npcManager.inventory.maskCount--;
        maskObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human") && isInfected)
        {
            if( isMasked )
                return;
            //npcManager.inventory.healthyCount--;
            //npcManager.inventory.infectedCount++;
            other.GetComponent<HumanInfection>().Infect();
        }
    }
}
