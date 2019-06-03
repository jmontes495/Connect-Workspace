using System;
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

    public int GetAnimatioId(TypeOfPersonality personality)
    {
        for (int i = 0; i < characterAnimations.Length; i++)
        {
            if (characterAnimations[i].typePersonality == personality)
            {
                Debug.Log("personality : "+ personality + "characterAnimations[i].animationId: "+ characterAnimations[i].animationId);
                return characterAnimations[i].animationId;
            }
        }
        return 0;
    }

    public CharacterAnimationsData[] CharacterAnimations
    {
        get { return characterAnimations; }
    }
} 