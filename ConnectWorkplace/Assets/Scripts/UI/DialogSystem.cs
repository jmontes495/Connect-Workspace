using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Dialog dialogObject;
    [SerializeField]
    private RectTransform container;

    private EventManager eventManager;

    private void Start()
    {
        foreach(Transform child in container.transform)
        {
            Destroy(child.gameObject);
        }
        eventManager = FindObjectOfType<EventManager>();
        eventManager.AddListener(SetDialogue);
    }

    private void SetDialogue(string text)
    {
        DOVirtual.DelayedCall(0.5f * container.childCount, () => CreateDialogue(text));
    }

    private void CreateDialogue(string text)
    {
        Dialog dialog = Instantiate(dialogObject);
        dialog.transform.SetParent(container);
        dialog.transform.DOScale(1f, 0f);
        dialog.transform.SetAsFirstSibling();
        dialog.Disappear();
        dialog.SetText(text);
        dialog.Appear();
    }

    private void OnDestroy()
    {
        eventManager.RemoveListener(SetDialogue);
    }

}
