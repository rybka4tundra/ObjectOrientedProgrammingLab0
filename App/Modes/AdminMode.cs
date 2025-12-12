public class AdminMode : Mode
{
    public override string Name { get; set; }
    public override bool IsWorking { get; set; }
    public override List<Command> Commands { get; set; }
    public override Command? MainCommand { get; set; }
    protected override string _helpText { get; set; }
    public AdminMode()
    {
        Name = "admin";
        IsWorking = false;
        Commands = [new List()];
        MainCommand = null;
        _helpText = _generateHelpText();
    }
}