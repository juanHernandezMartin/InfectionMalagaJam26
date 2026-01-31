using DG.Tweening;
using UnityEngine;

public class FactoryAnimation : MonoBehaviour
{
    public float clickAnimStrength;
    public Transform modelTransform;

    private Tween clickTween;
    private Vector3 initialScale;

    public void Start()
    {
        initialScale = modelTransform.localScale;
    }

    public void StartClickAnimation()
    {
        if (clickTween != null && clickTween.IsActive())
        {
            clickTween.Kill();
            modelTransform.localScale = initialScale;
        }
        clickTween = modelTransform.DOPunchScale(new Vector3(clickAnimStrength, clickAnimStrength, clickAnimStrength), 0.2f, 1, 0);
    }
}
