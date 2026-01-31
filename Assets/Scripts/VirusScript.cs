using UnityEngine;

public class VirusScript : MonoBehaviour
{
    public GameObject virusPrefab;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Virus collided with: " + other.name);
        if (other.CompareTag("Human"))
        {
            other.GetComponent<HumanInfection>().Infect();
            Destroy(virusPrefab);
        }
    }
}
