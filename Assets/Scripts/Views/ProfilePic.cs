using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePic : MonoBehaviour
{
    public List<Sprite> Profiles;
    public List<string> Names;
    public TextMeshProUGUI Name;
    public Image pic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pic.sprite = Profiles[(int)DeckController.Instance.GetPlayerSuit()];
        Name.text = Names[(int)DeckController.Instance.GetPlayerSuit()];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
