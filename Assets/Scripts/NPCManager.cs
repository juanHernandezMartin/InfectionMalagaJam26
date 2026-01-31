using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab;
    public int NPCAtStart = 20;

    void Start()
    {
        for(int i = 0; i < NPCAtStart; i++)
        {
            CrearNPC();
        }
    }

    void CrearNPC()
    {
        Vector3 humanPosition = new Vector3(0, 0 ,0);
        GameObject newNPC = Instantiate(npcPrefab, humanPosition, Random.rotation);
        newNPC.transform.parent = transform;
        Debug.Log($"NPC creado en: {newNPC.transform.position}");
    }



}