class Program
{
    private static VendingMachine VendingMachine {get; set;} = new VendingMachine();
    private static bool ProgramModeIsWorkingFlag = true;
    private static bool DepositModeIsWorkingFlag = false;
    private static bool AdminModeIsWorkingFlag = false;
    private static bool AddModeIsWorkingFlag = false;

    //Reads users prompt and return a command from it 
    private static string Prompt() {
        string? line;
        while(true){
            line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line)) {
                break;
            }
        }
        return line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
    }

    //Executes single prompt
    private static bool PromptExecutor(Dictionary<string, Action> commandMap, Func<string, bool>? tryExecuteMainCommand = null) {
        string prompt = Prompt();
        if (commandMap.TryGetValue(prompt, out Action action)) {
            action();
            return true;
        } else if (tryExecuteMainCommand != null && tryExecuteMainCommand(prompt)) {
            return true;
        } else {
            return false;
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
        <int CoinNominal> - Insert coin with nominal <int>.
        quit - Quit putting a deposit.

        """);
    }

    //Quits deposit mode
    private static void QuitDepositMode() {
        DepositModeIsWorkingFlag = false;
    }

    //Inserts coin into vending machine
    private static void InsertCoin(int coinValue) {
        if (VendingMachine.InsertCoin(coinValue)) {
            Console.WriteLine("SUCCESS: Coin was put in deposit");
        } else {
            Console.WriteLine("FAIL: Coins with this nominal is unacaptable");
        }
    }

    //Check if prompt can be parsed and if yes than executes main command 
    private static bool TryExecuteDeposit(string prompt){
        if (int.TryParse(prompt, out int parsedPrompt)) {
            InsertCoin(parsedPrompt);
            return true;
        } else {
            return false;
        }
    }

    //Enter deposit mode
    private static void DepositMode() {
        DepositModeIsWorkingFlag = true;
        DepositModeHelp();
        Dictionary<string, Action> commandMap = new Dictionary<string, Action>();
        commandMap.Add("help", DepositModeHelp);
        commandMap.Add("quit", QuitDepositMode);
        while (DepositModeIsWorkingFlag)
        {
            PromptExecutor(commandMap, TryExecuteDeposit); 
        }
    }

    //Prints list of commands for add mode
    private static void AddModeHelp() {
        CommandRules();
        Console.WriteLine("""
        --Add mode help--
        help - Prints list of commands for add mode.
        <string ProductName>:<int ProductPrice>:<int ProductCount> - adds a stack of product with name, price and count.
        quit - Quit putting a deposit.

        """);
    }

    //Check if prompt can be parsed and if yes than executes main command 
    private static bool TryExecuteAdd(string prompt){
        string[] tokens = prompt.Split(':');
        if (tokens.Length != 3){
            return false;
        }else if (int.TryParse(tokens[1], out int parsedPrice) && int.TryParse(tokens[2], out int parsedCount)) {
            VendingMachine.AddProductStack(tokens[0], parsedPrice, parsedCount);
            return true;
        } else {
            return false;
        }
    }

    //Quits add mode
    private static void QuitAddMode() {
        AddModeIsWorkingFlag = false;
    }

    //Enter add mode
    private static void AddMode() {
        AddModeIsWorkingFlag = true;
        AddModeHelp();
        Dictionary<string, Action> commandMap = new Dictionary<string, Action>();
        commandMap.Add("help", AddModeHelp);
        commandMap.Add("quit", QuitAddMode);
        while (AddModeIsWorkingFlag)
        {
            PromptExecutor(commandMap,TryExecuteAdd); 
        }
    }

    //Prints list of commands for admin mode
    private static void AdminModeHelp() {
        CommandRules();
        Console.WriteLine("""
        --Admin mode help--
        help - Prints list of commands for admin mode.
        list - Lists all available products and their price and count.
        collect - collects income.
        add - Enter add mode.
        delete - Enter delete mode.
        quit - Quit admin mode.

        """);
    }

    //Collects money from vending machine
    private static void Collect() {
        Console.WriteLine($"From vending machine were collected: {VendingMachine.Collect()}");
    }

    //Quits admin mode
    private static void QuitAdminMode() {
        AdminModeIsWorkingFlag = false;
    }

    //Enter admin mode
    private static void AdminMode() {
        AdminModeIsWorkingFlag = true;
        AdminModeHelp();
        Dictionary<string, Action> commandMap = new Dictionary<string, Action>();
        commandMap.Add("help", AdminModeHelp);
        commandMap.Add("list", List);
        commandMap.Add("collect", Collect);
        commandMap.Add("add", AddMode);
        commandMap.Add("quit", QuitAdminMode);
        while (AdminModeIsWorkingFlag)
        {
            PromptExecutor(commandMap); 
        }
    }

    //Prints list of commands for program mode
    private static void ProgramModeHelp() {
        CommandRules();
        Console.WriteLine("""
        --Program mode help--
        help - Prints list of commands.
        list - Lists all available products and their price and count.
        deposit - Enter deposit mode.
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

    //Enter program mode
    private static void ProgramMode() {
        ProgramModeHelp();
        Dictionary<string, Action> commandMap = new Dictionary<string, Action>();
        commandMap.Add("help", ProgramModeHelp);
        commandMap.Add("list", List);
        commandMap.Add("deposit", DepositMode);
        commandMap.Add("admin", AdminMode);
        commandMap.Add("quit", QuitProgramMode);
        while (ProgramModeIsWorkingFlag)
        {
            PromptExecutor(commandMap); 
        }
    }

    static void Main(string[] args)
    {    
        Console.WriteLine("--Vending Machine by Rybkin Andrey--\n");
        ProgramMode();
    }
}