using UnityEngine;

public class NPC : MonoBehaviour
{

    private GameObject world;


    void Start()
    {
        
    }
    public Vector3 position;

    public bool infectado;

    public void Awake()
    {
        infectado = false;
    }
}