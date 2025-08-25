using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRTE_View : RTE_View
{
    public Slider progressSlider;           
    public RectTransform markerPrefab;
    public Image inputPrefab;
    public RectTransform markerParent;
    public RectTransform buttonParent;
    public List<Sprite> buttonImages;

    public float duration = 5f;
    public float hitWindow = 0.05f;
    public KeyCode[] requiredKeys = { KeyCode.Space, KeyCode.Mouse0, KeyCode.Mouse1 };
    public float rangeOffset = 0.1f;

    private float elapsedTime;
    private int currentIndex;
    private bool isRunning = false;
    private List<float> targetPositions = new();
    private List<RectTransform> markerInstances = new();

    public void Start()
    {
        float minSpacing = hitWindow * 2f;

        for (int i = requiredKeys.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (requiredKeys[i], requiredKeys[j]) = (requiredKeys[j], requiredKeys[i]);
        }

        for (int i = 0; i < requiredKeys.Length; i++)
        {
            float baseT = (i + 1) / (float)(requiredKeys.Length + 1);
            float randomOffset = Random.Range(-rangeOffset, rangeOffset);

            float t = Mathf.Clamp(baseT + randomOffset, 0.05f, 0.95f);
            if (targetPositions.Count > 0)
            {
                float last = targetPositions[^1];
                if (Mathf.Abs(t - last) < minSpacing)
                {
                    t = Mathf.Clamp(last + minSpacing, 0.05f, 0.95f);
                }
            }
            targetPositions.Add(t);

            RectTransform marker = Instantiate(markerPrefab, markerParent);
            marker.anchorMin = new Vector2(t, 0.5f);
            marker.anchorMax = new Vector2(t, 0.5f);
            marker.anchoredPosition = Vector2.zero;
            markerInstances.Add(marker);

            Image input = Instantiate(inputPrefab, buttonParent);
            input.GetComponent<RectTransform>().anchorMin = new Vector2(t, 0.5f);
            input.GetComponent<RectTransform>().anchorMax = new Vector2(t, 0.5f);
            input.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            switch (requiredKeys[i]) 
            {
                case KeyCode.Space:
                    input.sprite = buttonImages[0];
                    break;
                case KeyCode.Mouse0:
                    input.sprite = buttonImages[1];
                    break;
                case KeyCode.Mouse1:
                    input.sprite = buttonImages[2];
                    break;
            }
        }
    }

    private void Update()
    {
        if (!isRunning) return;
        if (currentIndex >= requiredKeys.Length) 
        {
            Debug.Log("RTE Complete!");
            isRunning = false;
            TrainingManager.Instance.QTAResult(true, trainingType, difficulty);
            Destroy(gameObject);
            return;
        }

        // move slider
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        progressSlider.value = t;
        float target = targetPositions[currentIndex];
        float diff = Mathf.Abs(progressSlider.value - target);

        if (progressSlider.value > target + hitWindow)
        {
            Debug.Log("Failed! Missed inputs.");
            isRunning = false;
            TrainingManager.Instance.QTAResult(false, trainingType, difficulty);
            Destroy(gameObject);
        }
        else 
        {
            if (Input.GetKeyDown(requiredKeys[currentIndex]))
            {
                if (diff <= hitWindow)
                {
                    Debug.Log("Hit " + requiredKeys[currentIndex]);
                    currentIndex++;
                }
                else
                {
                    Debug.Log("Wrong timing!");
                    isRunning = false;
                    TrainingManager.Instance.QTAResult(false, trainingType, difficulty);
                    Destroy(gameObject);
                }
            }
        }
    }

    public override void StartRTE()
    {
        elapsedTime = 0f;
        currentIndex = 0;
        isRunning = true;
        duration = 5 - difficulty;
        progressSlider.value = 0f;
        progressSlider.maxValue = 1;
    }
}

