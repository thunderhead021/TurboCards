using System.Collections.Generic;
using UnityEngine;

public class Race_MiddlePart : MonoBehaviour
{
    public Race_Checkpoint checkpointPrefab;

    [HideInInspector]
    public List<(Race_Checkpoint row0, Race_Checkpoint row1, Race_Checkpoint row2, Race_Checkpoint row3)> parts = new();

    public void Setup(int rows, float startY) 
    {
        for (int i = 0; i < rows; i++) 
        {
            Race_Checkpoint checkpointRow0 = Instantiate(checkpointPrefab, transform);
            checkpointRow0.checkPointPos = new Vector2(-195, startY + 130 * i);

            Race_Checkpoint checkpointRow1 = Instantiate(checkpointPrefab, transform);
            checkpointRow1.checkPointPos = new Vector2(-65, startY + 130 * i);

            Race_Checkpoint checkpointRow2 = Instantiate(checkpointPrefab, transform);
            checkpointRow2.checkPointPos = new Vector2(65, startY + 130 * i);

            Race_Checkpoint checkpointRow3 = Instantiate(checkpointPrefab, transform);
            checkpointRow3.checkPointPos = new Vector2(195, startY + 130 * i);

            parts.Add((checkpointRow0, checkpointRow1, checkpointRow2, checkpointRow3));
        }
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        size.y = 100 * rows + 30 * (rows - 1);
        gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }
}
