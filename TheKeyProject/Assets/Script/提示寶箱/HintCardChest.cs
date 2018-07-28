using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HintCardChest : Interactable {
    
    public GameObject chestUI;

    private Animator animator;

    [Header("Hint Card")]
    public string hintCardCode;
    public Sprite hintCardSprite;
    public bool unlocked = false;
    

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
        
        unlocked = HintCardManager.instance.IsUnlocked(hintCardCode);
    }

    public override void Interact()
    {
        base.Interact();
        Open();
    }

    public void Open()
    {
        animator.SetBool("Opened", true);
        chestUI.SetActive(true);
    }

    public void Close()
    {
        animator.SetBool("Opened", false);
        chestUI.SetActive(false);
    }

    public void CompareInputAndHintCode(TMP_InputField inputField)
    {
        string text = inputField.text;
        
        if(!unlocked && text.Equals(hintCardCode, StringComparison.InvariantCultureIgnoreCase))
        {
            BookManager.instance.AddPage(hintCardSprite);
            HintCardManager.instance.UnlockHintCard(hintCardCode);
            unlocked = true;
            Destroy(gameObject);
            Debug.Log("Unlocked " + hintCardCode);
        }
        else
        {
            Debug.Log("hint card not available" + hintCardCode);
        }

    }
    
}
