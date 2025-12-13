public class Delete : Command
{
    private VendingMachine _vendingMachine;
    private void _functionArgs(string args)
    {
        string[] tokens = args.Split(':');
        if (tokens.Length != 2 || !int.TryParse(tokens[0], out int parsedProductStackId) || !uint.TryParse(tokens[1], out uint parsedProductCount))
            return;
        if (parsedProductStackId < 0 || parsedProductStackId >= _vendingMachine.Products.Count)
            return;
        if (parsedProductCount > _vendingMachine.Products[parsedProductStackId].Count)
            return;
        if (parsedProductCount == _vendingMachine.Products[parsedProductStackId].Count)
            _vendingMachine.RemoveProductStack(parsedProductStackId);
        else
            _vendingMachine.RemoveProducts(parsedProductStackId, parsedProductCount);
    }
    public Delete(VendingMachine vendingMachine) : base(
        "<int ProductStackID>:<int ProductCount>",
        "Removes ProductCount products from product stack with id ProductStackID.",
        null,
        null
        )
    {
        FunctionArgs = _functionArgs;
        this._vendingMachine = vendingMachine;
    }
}
