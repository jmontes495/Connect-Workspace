using UnityEngine;

[System.Serializable]
public struct CharacterAnimationsData
{
    public string personality;
    public TypeOfPersonality typePersonality;
    public int animationId;
}

public class CharactersAnimationConfigurations: ScriptableObject
{
    [SerializeField]
    private CharacterAnimationsData[] characterAnimations;

    public CharacterAnimationsData[] CharacterAnimations
    {
        get { return characterAnimations; }
    }
} 