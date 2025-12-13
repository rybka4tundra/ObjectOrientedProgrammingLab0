public class DepositMode : Mode
{
    public DepositMode(VendingMachine vendingMachine) : base(
        "deposit",
        [new List(vendingMachine)],
        null
        )
    { }
}