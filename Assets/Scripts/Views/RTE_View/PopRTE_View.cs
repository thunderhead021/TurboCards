using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopRTE_View : RTE_View
{
    public Balloon balloonPrefab;
    public Slider Timer;
    public RectTransform balloonParent;  
    public int balloonCount = 5;
    public float duration = 10f;

    private List<GameObject> balloons = new();
    private bool isRunning = false;

    public override void StartRTE()
    {
        Timer.maxValue = duration;
        Timer.value = duration;
        isRunning = true;
        Vector2 halfSize = balloonParent.rect.size * 0.5f;

        for (int i = 0; i < balloonCount * ( difficulty + 1 ); i++)
        {
            Vector2 pos = new(
                Random.Range(-halfSize.x, halfSize.x),
                Random.Range(-halfSize.y, halfSize.y)
            );

            Balloon b = Instantiate(balloonPrefab, balloonParent);
            b.GetComponent<RectTransform>().anchoredPosition = pos;
            b.Init(this);

            balloons.Add(b.gameObject);
        }
    }

    void Update()
    {
        if (!isRunning) return;

        Timer.value -= Time.deltaTime;
        if (Timer.value <= 0f)
        {
            TrainingManager.Instance.QTAResult(false, trainingType, difficulty);
            isRunning = false;
            Destroy(gameObject);
        }
    }

    public void PopBalloon(GameObject balloon)
    {
        balloons.Remove(balloon);
        Destroy(balloon);

        if (balloons.Count == 0)
        {
            TrainingManager.Instance.QTAResult(true, trainingType, difficulty);
            isRunning = false;
            Destroy(gameObject);
        }
    }
}
