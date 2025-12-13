public class BaseCommand : Command
{
    public override string Name { get; set; }
    public override string Description { get; set; }
    public override Action? Function { get; set; }
    public override Action<string>? FunctionArgs { get; set; }
    public BaseCommand(string Name, string Description, Action? Function, Action<string>? FunctionArgs)
    {
        this.Name = Name;
        this.Description = Description;
        this.Function = Function;
        this.FunctionArgs = FunctionArgs;
    }
}
