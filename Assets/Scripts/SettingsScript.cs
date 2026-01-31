using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public int maxFps = 144;

    void Awake()
    {
        Application.targetFrameRate = maxFps;
    }
}
