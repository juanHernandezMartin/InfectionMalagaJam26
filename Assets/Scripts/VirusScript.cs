using UnityEngine;

public class VirusScript : MonoBehaviour
{
    public GameObject virusPrefab;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<HumanInfection>().Infect();
            Destroy(virusPrefab);
        }
    }
}
