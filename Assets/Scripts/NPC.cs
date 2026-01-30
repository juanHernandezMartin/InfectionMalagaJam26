using UnityEngine;

public class NPC : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public bool infectado;

    public void Awake()
    {
        infectado = false;
    }
}