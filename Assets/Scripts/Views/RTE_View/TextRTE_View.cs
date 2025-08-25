using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextRTE_View : RTE_View
{
    public Slider timer;
    public TextMeshProUGUI promptText;   
    public TMP_InputField playerInput;

    [SerializeField]
    private string[] easyWords = { "tea", "latte", "donut", "cake" };
    [SerializeField]
    private string[] mediumWords = { "cappuccino", "espresso", "brownie", "muffin" };
    [SerializeField]
    private string[] hardWords = { "strawberry shortcake", "chocolate croissant", "vanilla milkshake" };

    public override void StartRTE() 
    {
        StartCoroutine(StartEventCoroutine());
    }

    IEnumerator StartEventCoroutine()
    {
        playerInput.text = "";
        var currentTime = timer.value;
        switch (difficulty)
        {
            case 0:
                promptText.text = easyWords[Random.Range(0, easyWords.Length)];
                break;
            case 1:
                promptText.text = mediumWords[Random.Range(0, mediumWords.Length)];
                break;
            case 2:
                promptText.text = hardWords[Random.Range(0, hardWords.Length)];
                break;
            case 3:
                promptText.text = hardWords[Random.Range(0, hardWords.Length)] + " and " + easyWords[Random.Range(0, easyWords.Length)];
                break;
        }
        playerInput.Select();
        playerInput.ActivateInputField();
        while (currentTime > 0f)
        {
            if (playerInput.text.Trim() == promptText.text)
            {
                TrainingManager.Instance.QTAResult(true, trainingType, difficulty);
                playerInput.interactable = false;
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
            currentTime -= 0.1f;
            timer.value = currentTime;
        }
        TrainingManager.Instance.QTAResult(false, trainingType, difficulty);
        timer.value = 0f;

        Destroy(gameObject);
    }
}
