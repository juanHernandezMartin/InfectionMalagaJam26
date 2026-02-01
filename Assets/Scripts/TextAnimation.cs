using DG.Tweening;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    void Start()
    {
       transform.DOLocalRotate(new Vector3(0, 0, 1.5f), 2f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true).SetEase(Ease.InOutSine);
       transform.DOMoveY(transform.position.y + 0.5f, 2f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true).SetEase(Ease.InOutSine); 
    }
}
