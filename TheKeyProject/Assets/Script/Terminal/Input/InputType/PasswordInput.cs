

public class PasswordInput : InputStrategy
{

    public void DoInput(string userInput, TerminalController controller)
    {
        userInput = userInput.Trim();
        controller.InputPassword(userInput);
        controller.InputStrategy = new CommandInput();
    }

}
