public enum TypeOfPersonality
{
    LongLegs = 0,
    ReclinerLover = 1,
    TheStretcher = 2,
    Otaku = 3,
    PaperFolder = 4,
    Thirstee = 5,
    Metalhead = 6,
    Smoker = 7,
    SoundSensible = 8,
    Gamer = 9,
    Pyromaniac = 10,
    SuperSerious = 11
}

public class PersonalityDescription
{
    public static string GetTraitDescription(TypeOfPersonality trait)
    {

        switch (trait)
        {
            case TypeOfPersonality.LongLegs:
                return "Long Legs: Kicks whoever is in front. <color=red>(-3)</color>";
            case TypeOfPersonality.ReclinerLover:
                return "Recliner Lover: Will recline until invading their back neighbor's personal space. <color=red>(-3)</color>";
            case TypeOfPersonality.TheStretcher:
                return "Stretcher: Yawns and extends the arms beyond the lateral limits of the desk, sometimes knocking things down. <color=red>(-3)</color>";
            case TypeOfPersonality.Otaku:
                return "Otaku: Makes other otakus sitting in front or beside productive <color=green>(+5)</color>. Has figurines in the table that may be knocked down <color=red>(-3)</color>.";
            case TypeOfPersonality.PaperFolder:
                return "Paper Folder: The origami creations sitting on their table bring joy (thus productivity) to everybody beside and in front of them. <color=green>(+4)</color>";
            case TypeOfPersonality.Thirstee:
                return "Thirstee: Always has a glass of water. Careful you don't knock it down. <color=red>(-3)</color>";
            case TypeOfPersonality.Metalhead:
                return "Metalhead: Makes metalheads beside them productive through headbanging <color=green>(+5)</color>. Will annoy sound sensitive people beside them <color=red>(-4)</color>.";
            case TypeOfPersonality.Smoker:
                return "Smoker: Annoys everyone beside them who doesn't smoke. <color=red>(-6)</color>";
            case TypeOfPersonality.SoundSensible:
                return "Sound Sensitive: Annoyed by people playing games <color=red>(-3)</color> or headbanging beside them <color=red>(-4)</color>.";
            case TypeOfPersonality.Gamer:
                return "Gamer: Makes otakus sitting anywhere near more productive <color=green>(+4)</color>. Annoys sound sensitive people sitting anywhere near them <color=red>(-3)</color>.";
            case TypeOfPersonality.Pyromaniac:
                return "Pyromaniac: Helpul lighting cigarettes to smokers besides them <color=green>(+3)</color>. Not so helpul setting origami pieces on fire beside them <color=red>(-6)</color>.";
            case TypeOfPersonality.SuperSerious:
                return "Super Serious: Not disturbed by anything, anywhere around. Somewhat disturbing to people beside them <color=red>(-2)</color>.";
            default:
                return "";
        }
    }
}