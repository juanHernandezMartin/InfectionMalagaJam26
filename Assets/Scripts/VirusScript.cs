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
            if (!other.GetComponent<HumanInfection>().isInfected)
            {
                other.GetComponent<HumanInfection>().Infect();
                virusManager.currentAmountOfVirus--;
                Destroy(virusPrefab);
            }
        }

        if(other.gameObject.CompareTag("Obstacle") )
        {
            Debug.Log("Virus hit obstacle, respawning");
            virusManager.currentAmountOfVirus--;
            virusManager.SpawnVirus();
            Destroy(virusPrefab);
        }
    }
}
