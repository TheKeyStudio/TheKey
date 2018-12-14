using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HintCard")]
public class HintCard : ScriptableObject{

    public string CodeName;
    public string HintCardCode;
    public Sprite HintCardSprite;
    public Sprite HintCardDescriptSprite;
    public bool Unlocked = false;
    
    
}
