using System.Collections.Generic;

public class SmallDebuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(-1);
        return new List<CardModel>() { Card };
    }
}

public class SmallDebuffPlayerCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(-1);
        return new List<CardModel>() { Card };
    }
}
