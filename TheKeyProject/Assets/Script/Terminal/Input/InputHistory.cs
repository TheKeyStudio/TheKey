using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHistory {

    readonly int maxHistorySize = 20;

    LinkedList<string> historyCommand = new LinkedList<string>(); //newest will be first, oldest will be last
    LinkedListNode<string> currentNode;

    public InputHistory(string newHistory)
    {
        historyCommand.AddFirst(newHistory);
        ResetNodeToFirst();
    }
    
	
    public void InsertNewHistory(string newHistory)
    {
        if(historyCommand.Count > maxHistorySize)
        {
            historyCommand.RemoveLast();
        }
        historyCommand.AddFirst(newHistory);
        ResetNodeToFirst();
    }
    
    public string GetNextHistory()
    {
        if(currentNode.Next == null)
        {
            return currentNode.Value;
        }

        string temp = currentNode.Value;
        currentNode = currentNode.Next;

        return temp;
    }

    public string GetPreviousHistory()
    {
        if (currentNode.Previous == null)
        {
            return currentNode.Value;
        }

        currentNode = currentNode.Previous;

        return currentNode.Value;
    }

	void ResetNodeToFirst()
    {
        currentNode = historyCommand.First;
        Debug.Log("Reset Node to :" + currentNode.Value);
    }

    
}
