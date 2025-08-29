using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : Manager<RaceManager>
{
    public RaceView raceView;

    public DeckView deckView;

    public CardView CardPrefab;

    public Transform CardShowPosition;

    [HideInInspector]
    public RaceController raceController = new();

    [HideInInspector]
    public float animationDuration = 2f;

    [HideInInspector]
    public bool RaceEnd = false;

    [HideInInspector]
    public bool AutoRunning = false;

    [HideInInspector]
    public int WinCount = 0;

    [HideInInspector]
    public int Heath = 5;

    protected override void Awake()
    {
        base.Awake();
        Instance.Shuffle();
    }

    public void CreateRaceTrack(int goal) 
    {
        raceController.SetGoal(goal);
        raceView.CreateRaceTrack((int)goal);
    }

    public void StartAutoRun() 
    {
        AutoRunning = true;
        StartCoroutine(StartAutoRunCoroutine());
    }

    public void StopAutoRun() 
    {
        AutoRunning = false;
    }

    public void SetAnimationSpeed(float speed) 
    {
        animationDuration = speed;
    }

    private IEnumerator StartAutoRunCoroutine()
    {  
        while (!RaceEnd && AutoRunning )
        {
            GetNextCardFromDeck();
            float elapsed = 0f;
            while (elapsed < animationDuration)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
    }

    private IEnumerator RemoveCardCoroutine(GameObject card)
    {
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(card);
    }

    public void Shuffle() 
    {
        DeckController.Instance.Shuffle();
    }

    public void GetNextCardFromDeck() 
    {
        var card = DeckController.Instance.GetNextCardFromDeck();
        var cardView = Instantiate(CardPrefab, CardShowPosition);
        cardView.Setup(deckView.GetCardSprite(card), card);

        Debug.Log(card.GetSuit().ToString() + "-" + card.GetCardValue().ToString());
        if (raceController.MovingToGoal(card))
        {
            Debug.Log("Winner " +  card.GetSuit().ToString() );
            RaceEnd = true;
            if (card.GetSuit() == DeckController.Instance.GetPlayerSuit())
                WinCount++;
            else
                Heath--;
            SceneManager.LoadScene("Result Scene");
        }
        else 
        {
            Debug.Log(card.GetSuit().ToString() + " moved to " + raceController.GetUnitPostion(card.GetSuit()));
            raceView.UpdateMiddlePart(raceController.GetRaceTrack());
            raceView.MoveUnit(card.GetSuit(), raceController.GetUnitPostion(card.GetSuit()));
            int cameraPos = raceController.GetTheHighestCurrentPos() - 3;
            if (cameraPos > 0)
            {
                raceView.MovingTrackView(cameraPos);
            }

            raceView.UpdateUnitEffects();

            StartCoroutine(RemoveCardCoroutine(cardView.gameObject));
        }
    }
}
