using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab;
    public int NPCAmount = 20;

    void Start()
    {
        for(int i = 0; i < NPCAmount; i++)
        {
            CrearNPC();
        }
    }

    void CrearNPC()
    {
        Vector3 humanPosition = new Vector3(0, 0 ,0);

        GameObject newNPC = Instantiate(npcPrefab, humanPosition, Quaternion.identity);
        newNPC.transform.parent = transform;
        Debug.Log($"NPC creado en: {newNPC.transform.position}");
    }

}