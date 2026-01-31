using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public GameObject virusPrefab;
    public float timeToSpawn = 3.0f;

    private int maxVirus = 5;
    private int currentVirus = 0;

    void Start()
    {
        InvokeRepeating("SpawnVirus", timeToSpawn, timeToSpawn);
    }

    public void SpawnVirus()
    {
        if( currentVirus >= maxVirus)
            return;
        Vector3 virusPosition = new Vector3(0, 0 ,0);
        GameObject newNPC = Instantiate(virusPrefab, virusPosition, Random.rotation);
        newNPC.transform.parent = transform;
        currentVirus++;
    }
}
