using System.Collections.Generic;

public class MaxBuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(4);
        return new List<CardModel>() { Card };
    }
}

public class MaxBuffEnemyCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(4);
        return new List<CardModel>() { Card };
    }
}
