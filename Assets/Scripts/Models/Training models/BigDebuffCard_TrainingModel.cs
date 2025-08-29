using System.Collections.Generic;

public class BigDebuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(-3);
        return new List<CardModel>() { Card };
    }
}

public class BigDebuffPlayerCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(-3);
        return new List<CardModel>() { Card };
    }
}

