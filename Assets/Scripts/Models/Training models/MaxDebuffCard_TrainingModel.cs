using System.Collections.Generic;

public class MaxDebuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(-4);
        return new List<CardModel>() { Card };
    }
}

public class MaxDebuffPlayerCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(-4);
        return new List<CardModel>() { Card };
    }
}

