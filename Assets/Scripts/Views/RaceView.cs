using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceView : MonoBehaviour
{
    public GameObject RaceTrack;
    public Race_Line RaceStartLine;
    public Race_MiddlePart RaceMiddlePart;
    public Race_Line RaceEndLine;
    public GameObject UnitPrefab;
    public List<Slider> Units = new();
    public List<Slider> MinimapUnits = new();
    [HideInInspector]
    public List<GameObject> CurrentTrack = new();
    public List<Image> UnitEffects = new();
    public List<Image> MiniUnitEffects = new();
    public List<Sprite> Effects = new();
    public List<Tooltip> UnitTooltips = new();
    public List<Tooltip> MiniUnitTooltips = new();

    public void UpdateUnitEffects() 
    {
        var unitBuff = RaceController.Instance.GetSuitBuff();

        for (int i = 0; i < 4; i++) 
        {
            if (unitBuff[i][0] > 0)
            {
                UnitEffects[i].gameObject.SetActive(true);
                UnitEffects[i].sprite = Effects[1];
                MiniUnitEffects[i].gameObject.SetActive(true);
                MiniUnitEffects[i].sprite = Effects[1];
                UnitTooltips[i].TooltipText = "+" + unitBuff[i][0] + " for the next " + unitBuff[i][1] + (unitBuff[i][1] > 1 ? " cards" : " card");
                MiniUnitTooltips[i].TooltipText = "+" + unitBuff[i][0] + " for the next " + unitBuff[i][1] + (unitBuff[i][1] > 1 ? " cards" : " card");
            }
            else if (unitBuff[i][0] < 0)
            {
                UnitEffects[i].gameObject.SetActive(true);
                UnitEffects[i].sprite = Effects[0];
                MiniUnitEffects[i].gameObject.SetActive(true);
                MiniUnitEffects[i].sprite = Effects[0];
                UnitTooltips[i].TooltipText = "-" + unitBuff[i][0] + " for the next " + unitBuff[i][1] + (unitBuff[i][1] > 1 ? " cards" : " card");
                MiniUnitTooltips[i].TooltipText = "-" + unitBuff[i][0] + " for the next " + unitBuff[i][1] + (unitBuff[i][1] > 1 ? " cards" : " card");
            }
            else
            {
                UnitEffects[i].gameObject.SetActive(false);
                MiniUnitEffects[i].gameObject.SetActive(false);
                UnitTooltips[i].TooltipText = "";
                MiniUnitTooltips[i].TooltipText = "";
            }
        }
    }

    public void UpdateMiddlePart(int[][] RaceTrack) 
    {
        int rows = RaceTrack.GetLength(0);
        int cols = RaceTrack[0].Length;
        int[][] middlePart = new int[rows][];
        for (int i = 0; i < rows; i++) 
        {
            middlePart[i] = new int[cols - 2];
        }
        for (int r = 0; r < rows; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                middlePart[r][c - 1] = RaceTrack[r][c];
            }
        }
        GameObject Race_Middle = GameObject.FindGameObjectWithTag("Race_Middle");
        if (Race_Middle != null) 
        {
            Race_Middle.GetComponent<Race_MiddlePart>().UpdateParts(middlePart, cols - 2);
        }
    }

    public void MoveUnit(Suit suit, int position) 
    {
        switch (suit)
        {
            case ((Suit)0):
                StartCoroutine(MoveUnitCoroutine(Units[0], position, RaceManager.Instance.animationDuration));
                StartCoroutine(MoveUnitCoroutine(MinimapUnits[0], position, RaceManager.Instance.animationDuration));
                break;
            case ((Suit)1):
                StartCoroutine(MoveUnitCoroutine(Units[1], position, RaceManager.Instance.animationDuration));
                StartCoroutine(MoveUnitCoroutine(MinimapUnits[1], position, RaceManager.Instance.animationDuration));
                break;
            case ((Suit)2):
                StartCoroutine(MoveUnitCoroutine(Units[2], position, RaceManager.Instance.animationDuration));
                StartCoroutine(MoveUnitCoroutine(MinimapUnits[2], position, RaceManager.Instance.animationDuration));
                break;
            case ((Suit)3):
                StartCoroutine(MoveUnitCoroutine(Units[3], position, RaceManager.Instance.animationDuration));
                StartCoroutine(MoveUnitCoroutine(MinimapUnits[3], position, RaceManager.Instance.animationDuration));
                break;
        }
        
    }

    private IEnumerator MoveUnitCoroutine(Slider unit, int position, float duration)
    {
        float elapsed = 0f;
        float start = unit.value;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            unit.value = Mathf.Lerp(start, position, t);
            yield return null;
        }

        unit.value = position;
    }

    public void MovingTrackView(int increment) 
    {
        StartCoroutine(MoveFromTo(gameObject, new Vector2(0, -130 * increment), RaceManager.Instance.animationDuration));
    }

    private IEnumerator MoveFromTo(GameObject unit, Vector2 end, float duration)
    {
        float elapsed = 0f;
        Vector2 start = unit.GetComponent<RectTransform>().anchoredPosition;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration; 
            unit.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(start, end, t);
            yield return null; 
        }

        unit.GetComponent<RectTransform>().anchoredPosition = end; 
    }

    public void CreateRaceTrack(int steps) 
    {
        CurrentTrack.Clear();
        float startPos = -1235;
        var start = Instantiate(RaceStartLine.gameObject, RaceTrack.transform);
        start.GetComponent<Race_Line>().Setup(startPos);
        Race_MiddlePart race_MiddlePart = Instantiate(RaceMiddlePart, RaceTrack.transform);
        race_MiddlePart.Setup(steps - 2, startPos + 130);
        var end = Instantiate(RaceEndLine.gameObject, RaceTrack.transform);
        end.GetComponent<Race_Line>().Setup(startPos + 130*(steps-1));
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        size.y = 100 * steps + 30 * (steps - 1);
        gameObject.GetComponent<RectTransform>().sizeDelta = size;

        CurrentTrack.Add(start);
        CurrentTrack.Add(race_MiddlePart.gameObject);
        CurrentTrack.Add(end);
        foreach (var unit in Units) 
        {
            unit.maxValue = steps-1;
            unit.minValue = 0;
            unit.value = 0;
        }
        foreach (var unit in MinimapUnits)
        {
            unit.maxValue = steps - 1;
            unit.minValue = 0;
            unit.value = 0;
        }
    }
}
