using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/NextLevelFiles")]
public class NextLevelFiles : TerminalFiles
{
    public int openLevel;
    public GameObject[] audioSourcesPrefabs;

    public override void Open(TerminalController controller)
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager.GetCurrentLevel() < openLevel)
        {
            SetData();
            gameManager.NextLevel();
            controller.LogString("Next level is opened.", "yellow");
            if(audioSourcesPrefabs == null)
            {
                return;
            }
            foreach(GameObject audioSourcePrefab in audioSourcesPrefabs)
            {
                AudioSource audioSource = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else
        {
            controller.LogString("Already Opened.", "yellow");
        }
    }

    
}
