using System.Collections.Generic;

public class BigBuffCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardFromPlayerSuit();
        Card.ModifyValue(3);
        return new List<CardModel>() { Card };
    }
}

public class BigBuffEnemyCard_TrainingModel : TrainingModel
{
    public override List<CardModel> Action()
    {
        CardModel Card = DeckController.Instance.GetARandomCardExclude();
        Card.ModifyValue(3);
        return new List<CardModel>() { Card };
    }
}
