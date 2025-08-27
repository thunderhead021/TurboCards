using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [HideInInspector]
    public DeckController DeckController = new();

    public void SetPlayerSuitTo0() 
    {
        DeckController.SetPlayerSuit((Suit)0);
    }

    public void SetPlayerSuitTo1()
    {
        DeckController.SetPlayerSuit((Suit)1);
    }

    public void SetPlayerSuitTo2()
    {
        DeckController.SetPlayerSuit((Suit)2);
    }

    public void SetPlayerSuitTo3()
    {
        DeckController.SetPlayerSuit((Suit)3);
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Training Scene");
    }
}
