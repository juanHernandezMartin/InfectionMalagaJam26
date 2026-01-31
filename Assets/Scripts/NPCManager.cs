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
        for(int i = 0; i < 5; i++)
        {
            CrearNPC();
        }
    }

    void CrearNPC()
    {
        Vector3 humanPosition = new Vector3(0, 0 ,0);

        GameObject newNPC = Instantiate(npcPrefab, humanPosition, Quaternion.identity);
        Debug.Log($"NPC creado en: {newNPC.transform.position}");
    }

}