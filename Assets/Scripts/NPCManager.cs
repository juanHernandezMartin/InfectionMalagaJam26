using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public int maxNPCs = 10;
    public GameObject npcPrefab;

    private List<GameObject> NPCs;

    public float rangeX = 20f;
    public float rangeZ = 20f;

    void Awake()
    {
        NPCs = new List<GameObject> ();
        while (NPCs.Count < maxNPCs)
            CrearNPC();
    }

    void Update()
    {

    }

    void CrearNPC()
    {
        if (NPCs.Count >= maxNPCs)
            return ;
            
        Vector3 randomPosition = GetRandomPosition();

        GameObject newNPC = Instantiate(npcPrefab, randomPosition, Quaternion.identity);

        NPCs.Add(newNPC);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-rangeX, rangeX);
        float z = Random.Range(-rangeZ, rangeZ);
        float y = 0f;

        return new Vector3(x, y, z);
    }

}