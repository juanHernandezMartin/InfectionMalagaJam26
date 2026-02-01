using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public GameObject virusPrefab;
    public float timeToSpawn = 3.0f;

    public NPCManager npcManager;

    private int maxVirus = 1;
    public int currentAmountOfVirus = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnVirus), timeToSpawn, timeToSpawn);
    }

    void Update()
    {
       maxVirus = 1 + (npcManager.currentHumans / 5);
    }

    public void SpawnVirus()
    {
        if( currentAmountOfVirus >= maxVirus)
            return;
        Vector3 virusPosition = new Vector3(0, 0 ,0);
        GameObject newVirus = Instantiate(virusPrefab, virusPosition, Random.rotation);
        newVirus.transform.parent = transform;
        newVirus.GetComponent<VirusReference>().virusScript.virusManager = this;
        currentAmountOfVirus++;
    }
}
