using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimationCaller : MonoBehaviour {

	public void PlayAnimation()
    {
        BookManager.instance.PlayAnimation();
    }
}
