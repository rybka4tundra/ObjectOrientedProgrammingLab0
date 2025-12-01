class Program
{
    private static VendingMachine VendingMachine {get; set;} = new VendingMachine();
    private static bool IsWorkingFlag = true;

    //Greates user
    private static void Great() {
        Console.WriteLine("--Vending Machine by Rybkin Andrey--");
    }

    //Sugests the user to enter a command and return this command
    private static string Command() {
        Console.WriteLine("Please enter command:");
        var command = Console.ReadLine(); 
        if (command != null) {
            return command;
        } else {
            return "";
        }
        
    }

    //Prints list of commands
    private static void Help() {
        Console.WriteLine(@"
        help - Prints list of commands
        list - Lists all available products and their price and count
        deposit - Insert coins in vending machine
        select - Select product and get it if there is enough coins on deposit. Decrease deposit by price of product
        change - Get left deposit
        admin - Enter admin mode
        quit - Quits program");
    }
    
    //Quits programm
    private static void Quit() {
        IsWorkingFlag = false;
    }

    static void Main(string[] args)
    {    
        Great();
        while (IsWorkingFlag)
        {
            Help();
            switch (Command()) {
                case "help":
                    Help();
                    break;
                case "quit":
                    Quit();
                    break;
                default:
                    break;

            }
        }
    }
}