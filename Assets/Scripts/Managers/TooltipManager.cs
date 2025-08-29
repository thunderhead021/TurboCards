public class TooltipManager : Manager<TooltipManager>
{
    public Tooltip_View Tooltip_View;

    public void SetText(string Header, string TooltipText) 
    {
        Tooltip_View.SetText(Header, TooltipText);
    }

    public void Show() 
    {
        Instance.Tooltip_View.gameObject.SetActive(true);
    }

    public void Hide() 
    {
        Instance.Tooltip_View.gameObject.SetActive(false);
    }
}
