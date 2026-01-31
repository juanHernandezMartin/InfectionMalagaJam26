using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private Transform world;
    
    public GameObject npcPrefab;

    void Start()
    {
        world = this.gameObject.transform;
        int i = 0;
        while (i < 10)
            CrearNPC();
    }

    void CrearNPC()
    {
        Vector3 humanPosition = new Vector3(0, 0 ,0);

        GameObject newNPC = Instantiate(npcPrefab, humanPosition, Quaternion.identity);
        Debug.Log($"NPC creado en: {newNPC.transform.position}");
    }

}