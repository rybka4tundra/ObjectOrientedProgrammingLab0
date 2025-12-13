public class VendingMachineMode : Mode
{
    public VendingMachineMode(VendingMachine vendingMachine) : base(
        "vending machine",
        [
            new AdminMode(vendingMachine),
            new List(vendingMachine),
            new DepositMode(vendingMachine),
            new BuyMode(vendingMachine)
            ],
        null
        )
    { }
}