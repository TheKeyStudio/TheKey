using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour {
    
    private Image[] childImgs;
    private Button[] buttons;

    public LevelDoor levelDoor;

    private void Awake()
    {
        buttons = gameObject.transform.GetComponentsInChildren<Button>();

        childImgs = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childImgs[i] = transform.GetChild(i).GetComponent<Image>();
            Debug.Log(childImgs[i].name);
        }
            
        for(int index = 0; index < buttons.Length; index++)
        {
            int closureIndex = index; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(delegate { OnClick(closureIndex); });
            buttons[closureIndex].interactable = false;
        }

        for (int index = 0; index < buttons.Length; index++)
        {

            Debug.Log(index + ":" + buttons[index].name);
        }

        gameObject.SetActive(false);
    }

    private void OnClick(int index)
    {
        Debug.Log("Onclick index:" + index);
        levelDoor.ToLevel(index + 1);
    }

    public void AvailableButton(int number)
    {
        for(int i = 0; i < number; i++)
        {
            childImgs[i].color = Color.red;
            buttons[i].interactable = true;
        }
        for(int i = number; i < childImgs.Length; i++)
        {
            childImgs[i].color = Color.white;
            buttons[i].interactable = false;
        }
    }
}
