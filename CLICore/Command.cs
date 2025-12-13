public abstract class Command
{
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual Action? Function { get; set; }
    public virtual Action<string>? FunctionArgs { get; set; }
    public Command(string Name, string Description, Action? Function, Action<string>? FunctionArgs)
    {
        this.Name = Name;
        this.Description = Description;
        this.Function = Function;
        this.FunctionArgs = FunctionArgs;
    }
    public void Run() { Function!(); }//TODO: Might be unsafe
    public void Run(string args) { FunctionArgs!(args); }//TODO: Might be unsafe
    public override string ToString() { return $"{Name} - {Description}"; }
}