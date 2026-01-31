using UnityEngine;

public class VirusScript : MonoBehaviour
{
    [HideInInspector]
    public VirusManager virusManager;
    public GameObject virusPrefab;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            other.GetComponent<HumanInfection>().Infect();
            virusManager.currentVirus--;
            Destroy(virusPrefab);
        }
    }
}
