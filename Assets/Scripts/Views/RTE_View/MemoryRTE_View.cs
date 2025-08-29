using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryRTE_View : RTE_View
{
    public Button[] gridButtons;
    public Color highlightColor = Color.yellow;
    public int sequenceLength = 4;    
    public float highlightTime = 0.6f;
    public float delayBetween = 0.3f; 

    private List<int> sequence = new();
    private int playerIndex = 0;
    private bool isInputPhase = false;

    public override void StartRTE()
    {
        playerIndex = 0;
        isInputPhase = false;
        for (int i = 0; i < sequenceLength + difficulty; i++)
        {
            sequence.Add(Random.Range(0, gridButtons.Length));
        }
        StartCoroutine(ShowSequence());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gridButtons.Length; i++)
        {
            int index = i;
            gridButtons[i].onClick.AddListener(() => OnCellClick(index));
        }
    }

    private IEnumerator ShowSequence()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < sequence.Count; i++)
        {
            int index = sequence[i];
            Image img = gridButtons[index].GetComponent<Image>();
            Color original = img.color;

            img.color = highlightColor;
            yield return new WaitForSeconds(highlightTime);

            img.color = original;
            yield return new WaitForSeconds(delayBetween);
        }

        // allow input
        isInputPhase = true;
        foreach (var button in gridButtons) 
        {
            button.interactable = true;
        }
    }

    void OnCellClick(int index)
    {
        if (!isInputPhase) return;

        if (sequence[playerIndex] == index)
        {
            playerIndex++;
            if (playerIndex >= sequence.Count)
            {
                SendResult(true);
            }
        }
        else
        {
            SendResult(false);
        }
    }
}
