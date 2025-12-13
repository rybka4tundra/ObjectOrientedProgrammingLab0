public class List : Command
{
    private VendingMachine _vendingMachine;
    private void _function() { Console.WriteLine(_vendingMachine); }
    public List(VendingMachine vendingMachine) : base(
        "list",
        "Lists all available products and their price and count.",
        null,
        null
        )
    {
        Function = _function;
        this._vendingMachine = vendingMachine;
    }
}
