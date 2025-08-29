using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [HideInInspector]
    public DeckController DeckController = new();

    [HideInInspector]
    public int round = 0;

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
        round = 0;
        SceneManager.LoadScene("Training Scene");   
    }

    public void NewGame()
    {
        DeckController.Instance.Reset();
        round++;
        SceneManager.LoadScene("Start Scene");
    }
}
