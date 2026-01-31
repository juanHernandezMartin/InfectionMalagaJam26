using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject humanPrefab;
    public float timeToSpawn = 1.0f;
    public int StartingHumans = 3;
    public int maxHumans = 20;

    [HideInInspector]
    public int currentHumans = 0;

    void Start()
    {
        for (int i = 0; i < StartingHumans; i++)
        {
            SpawnHuman();
        }
        InvokeRepeating(nameof(SpawnHuman), timeToSpawn, timeToSpawn);
    }

    public void SpawnHuman()
    {
        if( currentHumans >= maxHumans)
            return;
        Vector3 humanPosition = new Vector3(0, 0 ,0);
        GameObject newNPC = Instantiate(humanPrefab, humanPosition, Random.rotation);
        newNPC.transform.parent = transform;
        newNPC.GetComponent<HumanInfection>().npcManager = this;
        currentHumans++;
    }



}