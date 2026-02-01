using UnityEngine;
using UnityEngine.Video;

public class MoonAnimation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public void Update()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
