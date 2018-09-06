using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HintCard : MonoBehaviour {

    [SerializeField] private string codeName;
    [SerializeField] private string hintCardCode;
    [SerializeField] private Sprite hintCardSprite;
    [SerializeField] private bool unlocked = false;

    public string HintCardCode
    {
        get
        {
            return hintCardCode;
        }
    }

    public Sprite HintCardSprite
    {
        get
        {
            return hintCardSprite;
        }
    }

    public bool Unlocked
    {
        get
        {
            return unlocked;
        }
        set
        {
            unlocked = value;
        }
    }

    public string CodeName
    {
        get
        {
            return codeName;
        }

        set
        {
            codeName = value;
        }
    }

    // Use this for initialization
    void Start () {
        unlocked = HintCardManager.instance.IsUnlocked(HintCardCode);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
