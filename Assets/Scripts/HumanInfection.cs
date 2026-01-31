using UnityEngine;

public class HumanInfection : MonoBehaviour
{
    public Material infectedMaterial;
    public Renderer humanRenderer;
    public float maskDuration = 10f;
    public GameObject maskObject;
    
    private bool isInfected = false;
    private bool isMasked = false;
    private float maskDurationTimer = 0f;

    public float healthDuration = 20;

    public void Infect()
    {
        if (isInfected || isMasked)
            return;
        isInfected = true;
        humanRenderer.material = infectedMaterial;
    }

    public void Update()
    {
        if (healthDuration <= 0)
        {
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
        isMasked = true;
        maskDurationTimer = maskDuration;
        maskObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<HumanInfection>().Infect();
        }
    }
}
