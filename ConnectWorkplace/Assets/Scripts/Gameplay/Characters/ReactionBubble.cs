using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ReactionBubble : MonoBehaviour
{
    private GameObject bubble;

    [SerializeField]
    private Image employeeReaction;

    [SerializeField]
    private ReactionImagesConfig reactionsConfig;

    private Quaternion originalRotation;

    void Awake()
    {
        bubble = gameObject;
        bubble.transform.DOScale(Vector3.zero,0);
        originalRotation = transform.rotation;
    }

    public void ShowReaction(TypesOfReaction typeOfReaction)
    {
        bubble.transform.rotation = originalRotation;
        employeeReaction.sprite = reactionsConfig.GetImageByReaction(typeOfReaction);
        bubble.transform.DOScale(Vector3.one, 0.15f);
    }

    public void HideReaction()
    {
        bubble.transform.DOScale(Vector3.zero, 0.15f);
    }
}
