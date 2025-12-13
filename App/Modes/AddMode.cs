public class AddMode : Mode
{
    public AddMode(VendingMachine vendingMachine) : base(
        "add",
        [],
        new Add(vendingMachine)
        )
    { }
}