public class BaseCommand : Command
{
    public BaseCommand(string Name, string Description, Action? Function, Action<string>? FunctionArgs) : base(
        Name,
        Description,
        Function,
        FunctionArgs
    ){}
}
