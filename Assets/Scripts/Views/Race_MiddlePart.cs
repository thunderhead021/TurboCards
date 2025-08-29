using UnityEngine;

public class Race_MiddlePart : MonoBehaviour
{
    public Race_Checkpoint checkpointPrefab;

    public Race_Checkpoint[] part0;
    public Race_Checkpoint[] part1;
    public Race_Checkpoint[] part2;
    public Race_Checkpoint[] part3;

    public void Setup(int rows, float startY) 
    {
        part0 = new Race_Checkpoint[rows];
        part1 = new Race_Checkpoint[rows];
        part2 = new Race_Checkpoint[rows];
        part3 = new Race_Checkpoint[rows];

        for (int i = 0; i < rows; i++) 
        {
            Race_Checkpoint checkpointRow0 = Instantiate(checkpointPrefab, transform);
            checkpointRow0.checkPointPos = new Vector2(-195, startY + 130 * i);
            part0[i] = checkpointRow0;

            Race_Checkpoint checkpointRow1 = Instantiate(checkpointPrefab, transform);
            checkpointRow1.checkPointPos = new Vector2(-65, startY + 130 * i);
            part1[i] = checkpointRow1;

            Race_Checkpoint checkpointRow2 = Instantiate(checkpointPrefab, transform);
            checkpointRow2.checkPointPos = new Vector2(65, startY + 130 * i);
            part2[i] = checkpointRow2;

            Race_Checkpoint checkpointRow3 = Instantiate(checkpointPrefab, transform);
            checkpointRow3.checkPointPos = new Vector2(195, startY + 130 * i);
            part3[i] = checkpointRow3;
        }
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        size.y = 100 * rows + 30 * (rows - 1);
        gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }

    public void UpdateParts(int[][] partPoints, int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            part0[i].ShowEffect(partPoints[0][i]);
            part1[i].ShowEffect(partPoints[1][i]);
            part2[i].ShowEffect(partPoints[2][i]);
            part3[i].ShowEffect(partPoints[3][i]);
        }
    }
}
