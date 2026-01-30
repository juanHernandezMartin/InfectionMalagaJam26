using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    public float worldSpeed = 50f;

    // Update is called once per frame
    public void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationAmount * -worldSpeed * Time.deltaTime);
    }
}
