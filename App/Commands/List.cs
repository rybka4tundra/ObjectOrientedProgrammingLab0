public class List : Command
{
    public override string Name { get; set; }
    public override string Description { get; set; }
    public override Action? Function { get; set; }
    public override Action<string>? FunctionArgs { get; set; }


    private void _function()
    {
        Console.WriteLine("hello list");
    }
    public List()
    {
        Name = "list";
        Description = "Lists all available products and their price and count.";
        Function = _function;
    }
}
