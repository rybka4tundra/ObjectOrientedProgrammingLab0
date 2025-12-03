class Program
{
    private static VendingMachine VendingMachine {get; set;} = new VendingMachine();
    private static bool ProgramModeIsWorkingFlag = true;
    private static bool DepositModeIsWorkingFlag = false;

    //Reads users prompt and return command from it 
    private static string Prompt() {
        var line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line)) {
            return "";
        } else {
            return line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }

    //Executes a non numeric prompt e.g. "help", "list"
    private static bool NonNumericPromptExecutor(string prompt, Dictionary<string, Action> commandMap) {
        bool res = commandMap.TryGetValue(prompt, out Action action);
        if (res) {
            action();
        }
        return res;
    }

    //Executes a numeric prompt e.g. "123", "0111"
    private static bool NumericPromptExecutor(string prompt, Action<int> numericAction) {
        bool res = int.TryParse(prompt, out int ignoreInt);
        if (res) {
            numericAction(ignoreInt);
        }
        return res;
    }

    //Executes single prompt
    private static bool PromptExecutor(Dictionary<string, Action> commandMap, Action<int> numericAction = null) {
        string prompt = Prompt();
        if (NonNumericPromptExecutor(prompt, commandMap)) {
            return true;
        } else if (numericAction != null && NumericPromptExecutor(prompt, numericAction)) {
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
        <int> - Insert coin with nominal <int>.
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

    //Enter deposit mode
    private static void DepositMode() {
        DepositModeIsWorkingFlag = true;
        DepositModeHelp();
        Dictionary<string, Action> commandMap = new Dictionary<string, Action>();
        commandMap.Add("help", DepositModeHelp);
        commandMap.Add("quit", QuitDepositMode);
        while (DepositModeIsWorkingFlag)
        {
            PromptExecutor(commandMap, InsertCoin); 
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