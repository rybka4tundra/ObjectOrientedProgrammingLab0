public class List : Command
{
    private void _function() { Console.WriteLine("hello list"); }
    public List() : base("list", "Lists all available products and their price and count.", null, null) { Function = _function; }
}
