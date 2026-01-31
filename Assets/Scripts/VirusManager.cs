using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public GameObject virusPrefab;
    public float timeToSpawn = 3.0f;

    private int maxVirus = 5;
    [HideInInspector]
    public int currentVirus = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnVirus), timeToSpawn, timeToSpawn);
    }

    public void SpawnVirus()
    {
        if( currentVirus >= maxVirus)
            return;
        Vector3 virusPosition = new Vector3(0, 0 ,0);
        GameObject newVirus = Instantiate(virusPrefab, virusPosition, Random.rotation);
        newVirus.transform.parent = transform;
        newVirus.GetComponent<VirusReference>().virusScript.virusManager = this;
        currentVirus++;
    }
}
