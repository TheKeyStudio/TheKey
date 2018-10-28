using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/TextFiles")]
public class TextFiles : TerminalFiles
{

    [Range(0.1f, 2f)]
    public float contentFontSizeMultiple = 0.7f;

    public Color contentFontColor = new Color(0f, 1f, 0.5f);

    [TextArea(10, 10000)]
    public string content = "New Content";

    public override void Open(TerminalController controller)
    {
        string richTextContext = "<#" + ColorUtility.ToHtmlStringRGB(contentFontColor) + ">" +
            "<size=" + (contentFontSizeMultiple * 100f).ToString() + "%>" + content + 
            "</size>" + "</color>";

        controller.LogString(richTextContext);
    }
}
