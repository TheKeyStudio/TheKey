using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Terminal/Files/GraphFiles")]
public class GraphFiles : TerminalFiles {

    public GameObject imagePrefab;
    public override void Open(TerminalController controller)
    {
        SetData();
        TerminalImageControl imageControl = controller.ImageControl;
        imageControl.ShowImage(imagePrefab, controller);
    }

}
