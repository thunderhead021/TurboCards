using System.Collections.Generic;

public class SmallBuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(1);
        return new List<CardModel>() { Card };
    }
}

public class SmallBuffEnemyCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(1);
        return new List<CardModel>() { Card };
    }
}