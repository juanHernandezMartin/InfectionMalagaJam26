using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    public float worldSpeed = 50f;
    public float mouseSensitivity = 4f;

    // Update is called once per frame
    public void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal");
        rotationAmount = Mathf.Clamp(rotationAmount, -1f, 1f);
        transform.Rotate(Vector3.up, rotationAmount * -worldSpeed * Time.deltaTime);

        if( Input.GetMouseButton(0)) // Right mouse button held
        {
            float mouseRotationAmount = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(Vector3.up, mouseRotationAmount * -worldSpeed * Time.deltaTime);
        }
    }
}