using UnityEngine;

public class VirusRotation : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(Vector3.forward * Time.deltaTime);
    }
}
