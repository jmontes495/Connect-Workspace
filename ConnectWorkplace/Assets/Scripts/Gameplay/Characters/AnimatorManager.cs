using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public static readonly int WORK_STYLE_ID = Animator.StringToHash("WorkStyle");

    [SerializeField]
    private CharactersAnimationConfigurations animationConfiguration;
    [SerializeField]
    private Animator mainAnimator;

    public void Initialize(TypeOfPersonality personality)
    {
        int animationId = animationConfiguration.GetAnimatioId(personality);
        mainAnimator.SetInteger(WORK_STYLE_ID, animationId);
    }
}
