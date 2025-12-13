public class AdminMode : Mode
{
    public AdminMode(VendingMachine vendingMachine) : base(
        "admin",
        [
            new List(vendingMachine),
            new AddMode(vendingMachine)
            ],
        null
        )
    { }
}