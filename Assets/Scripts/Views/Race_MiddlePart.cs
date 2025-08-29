using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Race_MiddlePart : MonoBehaviour
{
    public Race_Checkpoint checkpointPrefab;

    [HideInInspector]
    public Race_Checkpoint[][] parts = new Race_Checkpoint[4][];

    public void Setup(int rows, float startY) 
    {
        parts[0] = new Race_Checkpoint[rows];
        parts[1] = new Race_Checkpoint[rows];
        parts[2] = new Race_Checkpoint[rows];
        parts[3] = new Race_Checkpoint[rows];

        for (int i = 0; i < rows; i++) 
        {
            Race_Checkpoint checkpointRow0 = Instantiate(checkpointPrefab, transform);
            checkpointRow0.checkPointPos = new Vector2(-195, startY + 130 * i);
            parts[0][i] = checkpointRow0;

            Race_Checkpoint checkpointRow1 = Instantiate(checkpointPrefab, transform);
            checkpointRow1.checkPointPos = new Vector2(-65, startY + 130 * i);
            parts[1][i] = checkpointRow1;

            Race_Checkpoint checkpointRow2 = Instantiate(checkpointPrefab, transform);
            checkpointRow2.checkPointPos = new Vector2(65, startY + 130 * i);
            parts[2][i] = checkpointRow2;

            Race_Checkpoint checkpointRow3 = Instantiate(checkpointPrefab, transform);
            checkpointRow3.checkPointPos = new Vector2(195, startY + 130 * i);
            parts[3][i] = checkpointRow3;
        }
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        size.y = 100 * rows + 30 * (rows - 1);
        gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }

    public void UpdateParts(int[][] partPoints)
    {
        for (int i = 0; i < 4; i++)
        {
            parts[0][i].ShowEffect(partPoints[0][i]);
            parts[1][i].ShowEffect(partPoints[1][i]);
            parts[2][i].ShowEffect(partPoints[2][i]);
            parts[3][i].ShowEffect(partPoints[3][i]);
        }
    }
}
