using DG.Tweening;
using UnityEngine;

public class TreeAnimation : MonoBehaviour
{
    public float animTime;
    public float animStrength;
    public float clickAnimStrength;

    private Tween clickTween;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
        animStrength = Random.Range(-animStrength ,-animStrength);
        animTime = Random.Range( animTime/2, animTime);
        transform.DOLocalRotate(new Vector3(animStrength, animStrength, animStrength), animTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public void StartClickAnimation()
    {
        if (clickTween != null && clickTween.IsActive())
        {
            clickTween.Kill();
            transform.localScale = initialScale;
        }
        clickTween = transform.DOPunchScale(new Vector3(clickAnimStrength, clickAnimStrength, clickAnimStrength), 0.2f, 1, 0);
    }
}
