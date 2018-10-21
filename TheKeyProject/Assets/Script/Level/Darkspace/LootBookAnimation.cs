using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBookAnimation : MonoBehaviour {

    private Animator animator;

    public GameObject addtiveScene;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        animator.SetTrigger("LootBook");
    }

    public void DoneAnimation()
    {
        Flowchart.BroadcastFungusMessage("LootedBook");
        Destroy(gameObject);
    }
}
