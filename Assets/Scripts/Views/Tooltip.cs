using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string HeaderText = "";
    [Multiline]
    public string TooltipText = "";

    private static LTDescr delay;

    public void MouseOver() 
    {
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipManager.Instance.SetText(HeaderText, TooltipText);
            TooltipManager.Instance.Show();
        });     
    }

    public void MouseOut() 
    {
        LeanTween.cancel(delay.uniqueId);
        TooltipManager.Instance.SetText("", "");
        TooltipManager.Instance.Hide();
    }  
}
