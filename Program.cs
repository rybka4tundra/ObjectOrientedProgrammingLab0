class Program
{
    private static VendingMachine VendingMachine {get; set;} = new VendingMachine();
    private static bool ProgramModeIsWorkingFlag = true;
    private static bool DepositModeIsWorkingFlag = true;

    //Reads users prompt and return command from it 
    private static string Prompt() {
        var line = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(line)) {
            return "";
        } else {
            return line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }

    //Prints rules for command entering
    private static void CommandRules() {
        Console.WriteLine("""
        --Command Rules--
        Command is a first word in the line.
        If there is a few words in line other words will be ignored.

        """);
    }
    
    //Lists all available products and their price and count
    private static void List() {
        Console.WriteLine(VendingMachine); 
    }

    //Prints list of commands for deposit mode
    private static void DepositModeHelp() {
        CommandRules();
        Console.WriteLine("""
        --Deposit mode help--
        help - Prints list of commands for deposit mode.
        <int> - Insert coin with nominal <int>.
        quit - Quit putting a deposit.

        """);
    }

    //Quits deposit mode
    private static void QuitDepositMode() {
        DepositModeIsWorkingFlag = false;
    }

    //Insert coins in vending machine
    private static void DepositMode() {
        DepositModeIsWorkingFlag = true;
        DepositModeHelp();
        while (DepositModeIsWorkingFlag)
        {
            string prompt = Prompt();
            int ignoreInt;
            if (int.TryParse(prompt, out ignoreInt)) {
                bool isCoinInserted = VendingMachine.InsertCoin(int.Parse(prompt));
                if (!isCoinInserted){
                    Console.WriteLine("Coins with this nominal is unacaptable");
                }
            } else {
                switch (prompt) {
                    case "help":
                        DepositModeHelp();
                        break;
                    case "quit":
                        QuitDepositMode();
                        break;
                    default:
                        break;
                }
            } 
        }
    }

    //Prints list of commands for program mode
    private static void ProgramModeHelp() {
        CommandRules();
        Console.WriteLine("""
        --Program mode help--
        help - Prints list of commands.
        list - Lists all available products and their price and count.
        deposit - Insert coins in vending machine.
        select - Select product and get it if there is enough coins on deposit. Decrease deposit by price of product.
        change - Get left deposit.
        admin - Enter admin mode.
        quit - Quits program.

        """);
    }

    //Quits program mode
    private static void QuitProgramMode() {
        ProgramModeIsWorkingFlag = false;
    }

    //Insert coins in vending machine
    private static void ProgramMode() {
        ProgramModeHelp();
        while (ProgramModeIsWorkingFlag)
        {
            switch (Prompt()) {
                case "help":
                    ProgramModeHelp();
                    break;
                case "list":
                    List();
                    break;
                case "deposit":
                    DepositMode();
                    break;
                case "quit":
                    QuitProgramMode();
                    break;
                default:
                    break;

            }
        }
    }

    static void Main(string[] args)
    {    
        Console.WriteLine("--Vending Machine by Rybkin Andrey--\n");
        ProgramMode();
    }
}