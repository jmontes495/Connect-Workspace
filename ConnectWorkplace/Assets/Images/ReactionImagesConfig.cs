using System.Collections.Generic;
using UnityEngine;

public class ReactionImagesConfig : ScriptableObject
{
    [SerializeField]
    private Sprite annoyingNoise;
    [SerializeField]
    private Sprite annoyingSmoke;
    [SerializeField]
    private Sprite goodAnime;
    [SerializeField]
    private Sprite goodGames;
    [SerializeField]
    private Sprite gotKicked;
    [SerializeField]
    private Sprite knockedFigures;
    [SerializeField]
    private Sprite knockedOrigami;
    [SerializeField]
    private Sprite knockedWater;
    [SerializeField]
    private Sprite stressful;
    [SerializeField]
    private Sprite burntOrigami;
    [SerializeField]
    private Sprite heartfulFigures;
    [SerializeField]
    private Sprite litCigarrette;
    [SerializeField]
    private Sprite chairClash;
    [SerializeField]
    private Sprite goodMusic;

    public Sprite GetImageByReaction(TypesOfReaction reaction)
    {
        switch (reaction)
        {
            case TypesOfReaction.AnnoyingNoise:
                return annoyingNoise;
            case TypesOfReaction.AnnoyingSmoke:
                return annoyingSmoke;
            case TypesOfReaction.GoodAnime:
                return goodAnime;
            case TypesOfReaction.GoodGames:
                return goodGames;
            case TypesOfReaction.GotKicked:
                return gotKicked;
            case TypesOfReaction.KnockedFigures:
                return knockedFigures;
            case TypesOfReaction.KnockedOrigami:
                return knockedOrigami;
            case TypesOfReaction.KnockedWater:
                return knockedWater;
            case TypesOfReaction.Stressful:
                return stressful;
            case TypesOfReaction.BurntOrigami:
                return burntOrigami;
            case TypesOfReaction.HeartfulFigures:
                return heartfulFigures;
            case TypesOfReaction.LitCigarrette:
                return litCigarrette;
            case TypesOfReaction.GoodMusic:
                return goodMusic;
            case TypesOfReaction.ChairClash:
                return chairClash;
            default:
                return annoyingNoise;

        }
    }

}
