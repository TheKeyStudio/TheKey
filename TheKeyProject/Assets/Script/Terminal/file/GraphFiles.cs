using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Terminal/Files/GraphFiles")]
public class GraphFiles : TerminalFiles {

    public Sprite sprite;
    public override void Open(TerminalController controller)
    {
        controller.ShowImage(sprite);
    }

}
