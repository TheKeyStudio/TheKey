

public class PasswordInput : InputStrategy
{

    public void DoInput(string userInput, TerminalController controller)
    {
        userInput = userInput.Trim();
        controller.inputPassword(userInput);
        controller.InputStrategy = new CommandInput();
    }

}
