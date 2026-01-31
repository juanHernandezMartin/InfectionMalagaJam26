using UnityEngine;

public class NPC : MonoBehaviour
{
    public Vector3 position;

    public bool infectado;

    public void Awake()
    {
        infectado = false;
    }
}