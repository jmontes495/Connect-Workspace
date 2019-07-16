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
        tween = canvasGroup.DOFade(1.0f, 0.3f);
    }

    public void Disappear()
    {
        tween = canvasGroup.DOFade(0.0f, 0.0f);
    }

    private void OnDestroy()
    {
        tween.Kill();   
    }
}
