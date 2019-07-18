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
    private int textCount;
    private int deleteCount;


    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        eventManager.AddListener(SetDialogue);
        ProductivityController.RestartedLevel += RestartScreen;
        Reset();
    }

    private void Reset()
    {
        foreach (Transform child in container.transform)
        {
            Destroy(child.gameObject);
        }
        textCount = 0;
        deleteCount = 0;
    }

    private void SetDialogue(string text)
    {
        textCount++;
        DOVirtual.DelayedCall(0.5f * textCount, () => CreateDialogue(text));
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
        DissapearExtraDialogues();
    }

    private void DissapearExtraDialogues()
    {
        if (textCount > 7)
        {
            deleteCount++;
            Dialog dialog = container.GetChild(0).GetComponent<Dialog>();
            DOVirtual.DelayedCall(0.5f * deleteCount, () => dialog.DestroyDialogue());
            textCount--;
        }
    }

    private void RestartScreen()
    {
        Reset();
    }

    private void OnDestroy()
    {
        ProductivityController.RestartedLevel -= RestartScreen;
        eventManager.RemoveListener(SetDialogue);
    }

}
