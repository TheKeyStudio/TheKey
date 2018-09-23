

public class CommandInput : InputStrategy {

    public void DoInput(string userInput, TerminalController controller)
    {
        userInput = userInput.ToLower();

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);
        bool isRespond = false;
        for (int i = 0; i < controller.inputCmds.Length; i++)
        {
            TerminalInputCommand inputCmd = controller.inputCmds[i];
            if (inputCmd.keyword == separatedInputWords[0])
            {
                inputCmd.Respond(controller, separatedInputWords);
                isRespond = true;
            }
        }

        if (!isRespond)
        {
            controller.LogString(separatedInputWords[0] +
                    " is unable, please type \"help\" to see all the commands.");
        }
    }
    
}
