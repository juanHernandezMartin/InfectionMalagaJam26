using UnityEngine;

public class HumanInfection : MonoBehaviour
{
    public Material infectedMaterial;
    public Renderer humanRenderer;
    
    private bool isInfected = false;

    public float healthDuration = 20;

    public void Infect()
    {
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<HumanInfection>().Infect();
        }
    }
}
