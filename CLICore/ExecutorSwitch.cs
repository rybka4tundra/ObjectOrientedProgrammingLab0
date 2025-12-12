public static class ExecutorSwitch
{
    public static void Run(List<Command> Commands, Command? MainCommand = null)
    {
        string prompt = Prompt.prompt;
        if (Commands.Exists(x => x.Name == prompt))
            Commands.Find(x => x.Name == prompt)!.Run();
        else if (MainCommand != null)
            MainCommand.Run(prompt);
            //TODO: make parse function
            //TODO: make returning statemetns for RUN method 
            //TODO: make MainCommnad abstract class with parse method in it
    }
}