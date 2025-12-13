public static class ExecutorSwitch
{
    public static void Run(string ModeName, List<Command> Commands, Command? MainCommand = null)
    {
        string prompt = Prompt.prompt;
        if (Commands.Exists(x => x.Name == prompt))
        {
            Command command = Commands.Find(x => x.Name == prompt)!;
            if (command.GetType().IsSubclassOf(typeof(Mode)))
            {
                Console.WriteLine($"--({ModeName})->({command.Name})--");
                command.Run();
                Console.WriteLine($"--({command.Name})->({ModeName})--");
            }
            else
                command.Run();
        }
        else if (MainCommand != null)
            MainCommand.Run(prompt);
        //TODO: make parse function
        //TODO: make returning statemetns for RUN method 
        //TODO: make MainCommnad abstract class with parse method in it
    }
}