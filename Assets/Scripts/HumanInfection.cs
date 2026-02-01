using UnityEngine;

public class HumanInfection : MonoBehaviour
{
    public GameObject virusParticleSystem;
    public Material infectedMaterial;
    private Material healthyMaterial;
    public Renderer humanRenderer;
    public float maskDuration = 10f;

    [HideInInspector]
    public NPCManager npcManager;
    public GameObject maskObject;
    
    public bool isInfected = false;
    private bool isMasked = false;
    private float maskDurationTimer = 0f;

    private float currentHealth;
    public float maxHealth = 60;
    public float maxVirusDuration = 20;
    public float currentVirusDuration;


    void Start()
    {
        currentHealth = maxHealth;
        healthyMaterial = humanRenderer.material;
        currentVirusDuration = maxVirusDuration;
    }

    public void Infect()
    {
        if (isInfected || isMasked)
            return;
        virusParticleSystem.SetActive(true);
        isInfected = true;
        npcManager.inventory.healthyCount--;
        npcManager.inventory.infectedCount++;
        humanRenderer.material = infectedMaterial;
        currentVirusDuration = maxVirusDuration;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            npcManager.currentHumans--;
            npcManager.inventory.infectedCount--;
            //npcManager.inventory.healthyCount--;
            Destroy(gameObject);
        }

        if(currentVirusDuration <= 0)
        {
            virusParticleSystem.SetActive(false);
            isInfected = false;
            npcManager.inventory.healthyCount++;
            npcManager.inventory.infectedCount--;
            currentVirusDuration = maxVirusDuration;
            humanRenderer.material = healthyMaterial;
        }

        if (isInfected)
        {
            currentHealth -= Time.deltaTime;
            currentVirusDuration -= Time.deltaTime;
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
