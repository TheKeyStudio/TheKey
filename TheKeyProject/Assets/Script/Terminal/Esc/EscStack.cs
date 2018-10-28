using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscStack : MonoBehaviour {

    public static EscStack instance = null;
    LinkedList<EscClose> stack = new LinkedList<EscClose>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pop();
        }
    }

    public void Push(EscClose escClose)
    {
        stack.AddFirst(escClose);
    }

    public void Pop()
    {
        if (stack.Count == 0)
            return;


        EscClose gonnaCloseItem = stack.First.Value;

        stack.RemoveFirst();

        gonnaCloseItem.Close();
    }
}
