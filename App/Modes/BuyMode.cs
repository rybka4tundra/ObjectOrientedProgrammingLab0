public class BuyMode : Mode
{
    public BuyMode(VendingMachine vendingMachine) : base(
        "buy",
        [new List(vendingMachine)],
        null
        )
    { }
}