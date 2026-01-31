using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float directionChangeInterval = 1f;
    public float directionChangeAmount = 30f;

    public float raycastDistance = 0.2f;
    public Transform raycastOrigin;
    

    public void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), directionChangeInterval, directionChangeInterval);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        
    }

    public void ChangeDirection()
    {
        float directionChange = Random.Range(-1f, 1f);
        transform.Rotate(Vector3.up, directionChange * directionChangeAmount * 0.5f);

        RaycastHit hit;
        //Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastDistance, Color.red, 1f);
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, raycastDistance))
        {
            // If we hit an obstacle, turn around
            transform.Rotate(Vector3.up, 45f);
        }
    }
}
