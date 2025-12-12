public abstract class Command
{
    public abstract string Name { get; set; }
    public abstract string Description { get; set; }
    public abstract Action? Function { get; set; }
    public abstract Action<string>? FunctionArgs { get; set; }
    public void Run() { Function!(); }//TODO: Might be unsafe
    public void Run(string args) { FunctionArgs!(args); }//TODO: Might be unsafe
    public override string ToString() { return $"{Name} - {Description}"; }
}