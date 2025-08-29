using System.Collections.Generic;

public class MedianDebuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(-2);
        return new List<CardModel>() { Card };
    }
}

public class MedianDebuffPlayerCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(-2);
        return new List<CardModel>() { Card };
    }
}