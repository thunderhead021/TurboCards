using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string HeaderText = "";
    public string TooltipText = "";


    public void MouseOver() 
    {
        TooltipManager.Instance.SetText(HeaderText, TooltipText);
        TooltipManager.Instance.Show();
    }

    public void MouseOut() 
    {
        TooltipManager.Instance.SetText("", "");
        TooltipManager.Instance.Hide();
    }  
}
