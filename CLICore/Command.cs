public abstract class Command
{
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual Action? Function { get; set; }
    public virtual Action<string>? FunctionArgs { get; set; }
    public void Run() { Function!(); }//TODO: Might be unsafe
    public void Run(string args) { FunctionArgs!(args); }//TODO: Might be unsafe
    public override string ToString() { return $"{Name} - {Description}"; }
}