using System.Text;
public abstract class Mode : Command
{
    //Make mode not editable after initialization
    //Add MainCommand to helptext
    //Check if enteering other mode then tell that you entering fromMode -> toMode
    protected bool IsWorking { get; set; }
    protected List<Command> Commands { get; set; }
    protected Command? MainCommand { get; set; }
    protected string _helpText { get; set; }
    public Mode(string Name, List<Command> Commands, Command? MainCommand)
    {
        this.Name = Name;
        this.Description = _description();
        this.Function = _start;
        this.FunctionArgs = null;
        this.Commands = Commands;
        this.MainCommand = MainCommand;
        IsWorking = false;
        _baseCommands();
        _helpText = _generateHelpText();
    }
    private void _start()
    {
        _enter();
        IsWorking = true;
        while (IsWorking)
            ExecutorSwitch.Run(Commands, MainCommand);
        _leave();
    }
    private void _baseCommands()
    {
        //check if commands exists
        Commands.Add(new BaseCommand("quit", $"Quits {Name} mode.", _quit, null));
        Commands.Add(new BaseCommand("help", $"Prints help text for {Name} mode.", _help, null));
    }
    private string _description()
    {
        return $"Enter {Name} mode";
    }
    private string _generateHelpText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"--{Name} mode help--");
        foreach (var command in Commands)
            sb.AppendLine(command.ToString());
        return sb.ToString();
    }
    private void _quit()
    {
        IsWorking = false;
    }
    private void _help()
    {
        Console.WriteLine(_helpText);
    }
    private void _enter()
    {
        Console.WriteLine($"--Entering {Name} mode--");
    }
    private void _leave()
    {
        Console.WriteLine($"--Leaving {Name} mode--");
    }
}