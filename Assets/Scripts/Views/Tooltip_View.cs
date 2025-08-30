using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Input;

[ExecuteInEditMode]
public class Tooltip_View : MonoBehaviour
{
    public TextMeshProUGUI HeaderField;
    public TextMeshProUGUI ContentField;
    public LayoutElement LayoutElement;
    public RectTransform RectTransform;
    public int characterWrapLimit;
    private string pattern = @"<sprite name=""[^""]*"">";
    private void Update()
    {
        if (Application.isEditor) 
        {
            int headerLength = Regex.Replace(HeaderField.text, pattern, "A").Length;
            int contentLength = Regex.Replace(ContentField.text, pattern, "A").Length;

            LayoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit);
        }

        var position = Input.mousePosition;
        var normalizedPosition = new Vector2(position.x / Screen.width, position.y / Screen.height);
        var pivot = CalculatePivot(normalizedPosition);
        RectTransform.pivot = pivot;
        transform.position = position;

    }

    public void SetText(string header, string content) 
    {
        HeaderField.gameObject.SetActive(!string.IsNullOrWhiteSpace(header));
        ContentField.gameObject.SetActive(!string.IsNullOrWhiteSpace(content));
        HeaderField.text = header;
        ContentField.text = content;
    }

    private Vector2 CalculatePivot(Vector2 normalizedPosition)

    {
        var pivotTopLeft = new Vector2(-0.05f, 1.05f);
        var pivotTopRight = new Vector2(1.05f, 1.05f);
        var pivotBottomLeft = new Vector2(-0.05f, -0.05f);
        var pivotBottomRight = new Vector2(1.05f, -0.05f);

        if (normalizedPosition.x < 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopLeft;
        }
        else if (normalizedPosition.x > 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopRight;
        }
        else if (normalizedPosition.x <= 0.5f && normalizedPosition.y < 0.5f)
        {
            return pivotBottomLeft;
        }
        else
        {
            return pivotBottomRight;
        }

    }
}
