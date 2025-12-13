public class Deposit : Command
{
    private VendingMachine _vendingMachine;
    private void _functionArgs(string args)
    {
        if (uint.TryParse(args, out uint parsedPrompt))
        {
            if (_vendingMachine.AcceptableCoinValues.Contains(parsedPrompt))
            {
                if (_vendingMachine.Coins.ContainsKey(parsedPrompt))
                    _vendingMachine.AddCoins(parsedPrompt, 1);
                else
                    _vendingMachine.AddCoinStack(new Coin(parsedPrompt), 1);
            }
        }
    }
    public Deposit(VendingMachine vendingMachine) : base(
        "<int CoinNominal>",
        "Insert coin with nominal CoinNominal.",
        null,
        null
        )
    {
        FunctionArgs = _functionArgs;
        this._vendingMachine = vendingMachine;
    }
}
