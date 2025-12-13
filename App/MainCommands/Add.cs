public class Add : Command
{
    private VendingMachine _vendingMachine;
    private void _functionArgs(string args)
    {
        string[] tokens = args.Split(':');
        if (tokens.Length == 3 && uint.TryParse(tokens[1], out uint parsedPrice) && uint.TryParse(tokens[2], out uint parsedCount))
            _vendingMachine.AddProductStack(new Product(tokens[0], parsedPrice), parsedCount);
    }
    public Add(VendingMachine vendingMachine) : base(
        "<string ProductName>:<int ProductPrice>:<int ProductCount>",
        "Adds a stack of product with name, price and count.",
        null,
        null
        )
    {
        FunctionArgs = _functionArgs;
        this._vendingMachine = vendingMachine;
    }
}
