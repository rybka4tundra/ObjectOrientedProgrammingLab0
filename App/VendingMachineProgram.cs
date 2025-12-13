public class VendingMachineProgram : ConsoleProgram {
    protected override Mode _startMode {get; set;}
    public VendingMachineProgram()
    {
        _startMode = new VendingMachineMode();
    }
}