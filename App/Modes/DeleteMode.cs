public class DeleteMode : Mode
{
    public DeleteMode(VendingMachine vendingMachine) : base(
        "delete",
        [],
        new Delete(vendingMachine)
        )
    { }
}