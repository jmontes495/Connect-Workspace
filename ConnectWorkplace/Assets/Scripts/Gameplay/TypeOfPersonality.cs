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
                return "Long Legs: Kicks whoever is in front.";
            case TypeOfPersonality.ReclinerLover:
                return "Recliner Lover: Will recline until invading their back neighbor's personal space.";
            case TypeOfPersonality.TheStretcher:
                return "Stretcher: Yawns and extends the arms beyond the lateral limits of the desk, sometimes knocking things.";
            case TypeOfPersonality.Otaku:
                return "Otaku: Makes other otakus sitting in front, left or right happy and productive. Has figurines in the table.";
            case TypeOfPersonality.PaperFolder:
                return "Paper Folder: The origami creations sitting on their table bring joy (thus productivity) to everybody beside and in front of them.";
            case TypeOfPersonality.Thirstee:
                return "Thirstee: Always has a glass of water. Careful you don't knock it down.";
            case TypeOfPersonality.Metalhead:
                return "Metalhead: Can bring productivity to metalheads beside them through headbanging. This will annoy sound sensitive people beside them.";
            case TypeOfPersonality.Smoker:
                return "Smoker: Annoys everyone beside them who doesn't smoke.";
            case TypeOfPersonality.SoundSensible:
                return "Sound Sensitive: Annoyed by people playing games or headbanging beside them.";
            case TypeOfPersonality.Gamer:
                return "Gamer: More productive when sitting anywhere near otakus. Annoys sound sensitive people sitting anywhere near them.";
            case TypeOfPersonality.Pyromaniac:
                return "Pyromaniac: May be helpul lighting cigarettes to smokers at their left or right. May be not so helpul setting origami pieces on fire.";
            case TypeOfPersonality.SuperSerious:
                return "Super Serious: Not disturbed by anything. Quite disturbing to people beside them.";
            default:
                return "";
        }
    }
}