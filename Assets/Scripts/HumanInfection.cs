using UnityEngine;

public class HumanInfection : MonoBehaviour
{
    public Material infectedMaterial;
    public Renderer humanRenderer;

    public void Infect()
    {
        humanRenderer.material = infectedMaterial;
    }
}
