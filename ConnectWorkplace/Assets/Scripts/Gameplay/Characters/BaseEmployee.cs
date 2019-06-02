using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridPosition;

public class BaseEmployee : MonoBehaviour
{
    private float productivity; //Value between 1 and 100

    private GridPosition currentPosition;

    private ReactionBubble reactionBubble;

    [SerializeField]
    private FacingOrientation initialFacing;

    private void Start()
    {
        currentPosition = new GridPosition();
        currentPosition.Initialize(initialFacing);
        reactionBubble = GetComponentInChildren<ReactionBubble>();
    }

    public void ReduceProductivity(float productivityLost)
    {
        productivity -= productivityLost;
    }

    public void IncreaseProductivity(float productivityGain)
    {
        productivity += productivityGain;
    }

    public GridPosition GetPosition()
    {
        return currentPosition;
    }

    public void ShowReaction(TypesOfReaction reaction)
    {
        reactionBubble.ShowReaction(reaction);
    }

    public void HideReaction( )
    {
        reactionBubble.HideReaction();
    }
}
