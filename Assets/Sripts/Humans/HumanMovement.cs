using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float directionChangeInterval = 1f;
    public float directionChangeAmount = 30f;
    

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
    }
}
