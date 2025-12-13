public class VendingMachineMode : Mode
{
    public VendingMachineMode() : base(
        "vending machine",
        new List<Command> { new AdminMode() },
        null
        )
    { }
}