using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Manager<AudioManager>
{
    public List<AudioClip> cardDrawnList;
    public List<AudioClip> charSelectList;
    public List<AudioClip> buttonClickList;

    public AudioSource audioSource;

    public void CharSelect()
    {
        audioSource.clip = charSelectList[Random.Range(0, charSelectList.Count)];
        audioSource.Play();
    }

    public void DrawCard()
    {
        audioSource.clip = cardDrawnList[Random.Range(0, cardDrawnList.Count)];
        audioSource.Play();
    }

    public void ButtonClick()
    {
        audioSource.clip = buttonClickList[Random.Range(0, buttonClickList.Count)];
        audioSource.Play();
    }
}
