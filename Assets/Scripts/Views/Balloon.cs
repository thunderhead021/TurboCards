using UnityEngine;

public class Balloon : MonoBehaviour
{
    private PopRTE_View popRTE_View;

    public void Init(PopRTE_View mgr)
    {
        popRTE_View = mgr;
    }

    public void PopBalloon()
    {
        popRTE_View.PopBalloon(gameObject);
    }
}
