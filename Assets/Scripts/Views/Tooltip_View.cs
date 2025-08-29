using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tooltip_View : MonoBehaviour
{
    public TextMeshProUGUI HeaderField;
    public TextMeshProUGUI ContentField;
    public LayoutElement LayoutElement;
    public int characterWrapLimit;

    private void Update()
    {
        int headerLength = HeaderField.text.Length;
        int contentLength = ContentField.text.Length;

        LayoutElement.enabled = (headerLength > characterWrapLimit ||  contentLength > characterWrapLimit) ? true : false;
    }

}
