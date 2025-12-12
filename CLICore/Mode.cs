using System.Text;
public abstract class Mode : Command
{
    //Make mode not editable after initialization
    public abstract bool IsWorking { get; set; }
    public abstract List<Command> Commands { get; set; }
    public abstract Command? MainCommand { get; set; }
    protected abstract string _helpText { get; set; }
    public override string Description { get; set; }
    public override Action? Function { get; set; }
    public override Action<string>? FunctionArgs { get; set; }

    public Mode()
    {
        Function = _start;
        Description = $"Enter {Name} mode";
    }
    protected void _start()
    {
        IsWorking = true;
        while (IsWorking)
            ExecutorSwitch.Run(Commands, MainCommand);
    }
    protected string _generateHelpText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"--{Name} mode help--");
        foreach (var command in Commands)
            sb.AppendLine(command.ToString());
        return sb.ToString();
    }
    protected void _quit()
    {
        IsWorking = false;
    }
    protected string _help()
    {
        return _helpText;
    }
}