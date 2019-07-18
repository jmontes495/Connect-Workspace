using UnityEngine;
using TMPro;
using DG.Tweening;


public class Dialog : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private CanvasGroup canvasGroup;

    private Tween tween;
    
    public void SetText(string txt)
    {
        text.text = txt;
    }

    public void Appear()
    {
        tween = canvasGroup.DOFade(1.0f, 0.5f);
    }

    public void Disappear()
    {
        tween = canvasGroup.DOFade(0.0f, 0.0f);
    }

    public void DestroyDialogue()
    {
        tween = DOVirtual.DelayedCall(5.0f, () =>
        {
            canvasGroup.DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
        });
    }

    private void OnDestroy()
    {
        tween.Kill();   
    }
}
