using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/BruteForce")]
public class BruteForceCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        separatedInputWords = separatedInputWords[1].Split(' ');
        if (separatedInputWords.Length == 2)
        {
            Debug.Log("Brute force");
            BruteForceController ctrler = controller.BruteForceCtrler;
            ctrler.BruteForce(separatedInputWords[0], separatedInputWords[1]);
        }
        else
        {
            controller.LogString("Smthing wrong");
        }
    }
}
