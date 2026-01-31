using UnityEngine;

public class FactoryUI : MonoBehaviour
{
    public GameObject slider;
    public GameObject buildinSign;
    public GameObject exangeSign;
    
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
