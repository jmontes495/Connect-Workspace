using UnityEngine;

public class CharacterEffectsManager : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField]
    private TypeOfPersonality characterPersonality;
    [SerializeField]
    private GameObject particleEffects;
    [SerializeField]
    private AudioSource audioSource;

    public void Initialize(TypeOfPersonality personality)
    {
        if (this.characterPersonality == personality)
        {
            if (particleEffects)
                particleEffects.gameObject.SetActive(true);
            if (audioSource)
                audioSource.Play();
        }
    }
}
