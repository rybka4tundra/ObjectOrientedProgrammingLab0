class Program
{
    static void Main(string[] args)
    {
        HashSet<uint> acceptableCoinValues = [1, 2, 5, 10];
        VendingMachineProgram vendingMachineProgram = new VendingMachineProgram(new VendingMachine(acceptableCoinValues));
        vendingMachineProgram.Run();
    }
}