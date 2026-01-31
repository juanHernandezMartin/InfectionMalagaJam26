using UnityEngine;

public class FactoryUI : MonoBehaviour
{
    public GameObject slider;
    public GameObject buildinSign;
    public GameObject exangeSign;
    public GameObject background;
    
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
