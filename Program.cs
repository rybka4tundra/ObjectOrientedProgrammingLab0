class Program
{
    private static readonly HashSet<uint> AcceptableCoinValues;

    private static readonly VendingMachine VendingMachine;
    private static bool ProgramModeIsWorkingFlag;
    private static bool DepositModeIsWorkingFlag;
    //private static bool AdminModeIsWorkingFlag;
    private static bool AddModeIsWorkingFlag;
    private static bool DeleteModeIsWorkingFlag;

    static Program()
    {
        AcceptableCoinValues = [1, 2, 5, 10];
        VendingMachine = new VendingMachine(AcceptableCoinValues);
        ProgramModeIsWorkingFlag = true;
        DepositModeIsWorkingFlag = false;
        // AdminModeIsWorkingFlag = false;
        AddModeIsWorkingFlag = false;
        DeleteModeIsWorkingFlag = false;
    }


    //Reads users prompt and return a command from it 
    private static string Prompt()
    {
        string? line;
        while (true)
        {
            line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                break;
            }
        }
        return line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
    }

    //Executes single prompt
    private static bool PromptExecutor(Dictionary<string, Action> commandMap, Func<string, bool>? tryExecuteMainCommand = null)
    {
        string prompt = Prompt();
        if (commandMap.TryGetValue(prompt, out Action? action))
        {
            action();
            return true;
        }
        else if (tryExecuteMainCommand != null && tryExecuteMainCommand(prompt))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Prints rules for command entering
    private static void CommandRules()
    {
        Console.WriteLine("""
        --Command Rules--
        Command is a first word in the line.
        If there is a few words in line other words will be ignored.

        """);
    }

    //Lists all available products and their price and count
    private static void List()
    {
        Console.WriteLine(VendingMachine);
    }

    //Prints list of commands for deposit mode
    private static void DepositModeHelp()
    {
        CommandRules();
        Console.WriteLine("""
        --Deposit mode help--
        help - Prints list of commands for deposit mode.
        <int CoinNominal> - Insert coin with nominal <int>.
        quit - Quit putting a deposit.

        """);
    }

    //Quits deposit mode
    private static void QuitDepositMode()
    {
        DepositModeIsWorkingFlag = false;
    }

    //Inserts coin into vending machine
    private static void InsertCoin(uint coinValue)
    {
        if (VendingMachine.Coins.ContainsKey(coinValue))
            VendingMachine.AddCoins(coinValue, 1);
        else
            VendingMachine.AddCoinStack(new Coin(coinValue), 1);
    }

    //Check if prompt can be parsed and if yes than executes main command 
    private static bool TryExecuteDeposit(string prompt)
    {
        if (uint.TryParse(prompt, out uint parsedPrompt))
        {
            if (AcceptableCoinValues.Contains(parsedPrompt))
            {
                InsertCoin(parsedPrompt);
                return true;
            }
        }
        return false;
    }

    //Enter deposit mode
    private static void DepositMode()
    {
        DepositModeIsWorkingFlag = true;
        DepositModeHelp();
        Dictionary<string, Action> commandMap = new()
        {
            { "help", DepositModeHelp },
            { "quit", QuitDepositMode }
        };
        while (DepositModeIsWorkingFlag)
        {
            PromptExecutor(commandMap, TryExecuteDeposit);
        }
    }

    //Prints list of commands for add mode
    private static void AddModeHelp()
    {
        CommandRules();
        Console.WriteLine("""
        --Add mode help--
        help - Prints list of commands for add mode.
        <string ProductName>:<int ProductPrice>:<int ProductCount> - adds a stack of product with name, price and count.
        quit - Quit add mode.

        """);
    }

    //Check if prompt can be parsed and if yes than executes main command 
    private static bool TryExecuteAdd(string prompt)
    {
        string[] tokens = prompt.Split(':');
        if (tokens.Length != 3)
        {
            return false;
        }
        else if (uint.TryParse(tokens[1], out uint parsedPrice) && uint.TryParse(tokens[2], out uint parsedCount))
        {
            VendingMachine.AddProductStack(new Product(tokens[0], parsedPrice), parsedCount);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Quits add mode
    private static void QuitAddMode()
    {
        AddModeIsWorkingFlag = false;
    }

    //Enter add mode
    private static void AddMode()
    {
        AddModeIsWorkingFlag = true;
        AddModeHelp();
        Dictionary<string, Action> commandMap = new()
        {
            { "help", AddModeHelp },
            { "quit", QuitAddMode }
        };
        while (AddModeIsWorkingFlag)
        {
            PromptExecutor(commandMap, TryExecuteAdd);
        }
    }

    //Prints list of commands for delete mode
    private static void DeleteModeHelp()
    {
        CommandRules();
        Console.WriteLine("""
        --Delete mode help--
        help - Prints list of commands for delete mode.
        <int ProductStackID>:<int ProductCount> - removes ProductCount products from product stack with id ProductStackID.
        quit - Quit delete mode.

        """);
    }

    private static void RemoveFromProductStack(int parsedProductStackId, uint parsedProductCount)
    {
        VendingMachine.RemoveProducts(parsedProductStackId, parsedProductCount);
    }

    //Check if prompt can be parsed and if yes than executes main command 
    private static bool TryExecuteDelete(string prompt)
    {
        string[] tokens = prompt.Split(':');
        if (tokens.Length != 2)
        {
            return false;
        }
        else if (int.TryParse(tokens[0], out int parsedProductStackId) && uint.TryParse(tokens[1], out uint parsedProductCount))
        {
            if (parsedProductStackId < 0 || parsedProductStackId >= VendingMachine.Products.Count)
                return false;
            RemoveFromProductStack(parsedProductStackId, parsedProductCount);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Quits delete mode
    private static void QuitDeleteMode()
    {
        DeleteModeIsWorkingFlag = false;
    }

    //Enter Delete mode
    private static void DeleteMode()
    {
        DeleteModeIsWorkingFlag = true;
        DeleteModeHelp();
        Dictionary<string, Action> commandMap = new()
        {
            { "help", DeleteModeHelp },
            { "quit", QuitDeleteMode }
        };
        while (DeleteModeIsWorkingFlag)
        {
            PromptExecutor(commandMap, TryExecuteDelete);
        }
    }

    //Prints list of commands for admin mode
    // private static void AdminModeHelp()
    // {
    //     CommandRules();
    //     Console.WriteLine("""
    //     --Admin mode help--
    //     help - Prints list of commands for admin mode.
    //     list - Lists all available products and their price and count.
    //     collect - collects income.
    //     add - Enter add mode.
    //     delete - Enter delete mode.
    //     quit - Quit admin mode.

    //     """);
    // }

    //Collects money from vending machine
    private static void Collect()
    {
        Console.WriteLine($"From vending machine were collected: DEPRECATED");
    }

    //Quits admin mode
    // private static void QuitAdminMode()
    // {
    //     AdminModeIsWorkingFlag = false;
    // }

    //Enter admin mode
    // private static void AdminMode()
    // {
    //     AdminModeIsWorkingFlag = true;
    //     AdminModeHelp();
    //     Dictionary<string, Action> commandMap = new()
    //     {
    //         { "help", AdminModeHelp },
    //         { "list", List },
    //         { "collect", Collect },
    //         { "add", AddMode },
    //         { "delete", DeleteMode },
    //         { "quit", QuitAdminMode }
    //     };
    //     while (AdminModeIsWorkingFlag)
    //     {
    //         PromptExecutor(commandMap);
    //     }
    // }

    //Prints list of commands for program mode
    private static void ProgramModeHelp()
    {
        CommandRules();
        Console.WriteLine("""
        --Program mode help--
        help - Prints list of commands.
        list - Lists all available products and their price and count.
        deposit - Enter deposit mode.
        select - Select product and get it if there is enough coins on deposit. Decrease deposit by price of product.
        change - Get left deposit.
        // admin - Enter admin mode.
        quit - Quits program.

        """);
    }

    //Quits program mode
    private static void QuitProgramMode()
    {
        ProgramModeIsWorkingFlag = false;
    }

    //Enter program mode
    // private static void ProgramMode()
    // {
    //     VendingMachineMode vendingMachineMode = new();
    //     ProgramModeHelp();
    //     Dictionary<string, Action> commandMap = new()
    //     {
    //         { "help", ProgramModeHelp },
    //         { "list", List },
    //         { "deposit", DepositMode },
    //         { "admin", vendingMachineMode.Run },
    //         { "quit", QuitProgramMode }
    //     };
    //     while (ProgramModeIsWorkingFlag)
    //     {
    //         PromptExecutor(commandMap);
    //     }
    // }

    static void Main(string[] args)
    {
        // Console.WriteLine("--Vending Machine by Rybkin Andrey--\n");
        // ProgramMode();
        VendingMachineMode vendingMachineMode = new(VendingMachine);
        vendingMachineMode.Run();

    }
}