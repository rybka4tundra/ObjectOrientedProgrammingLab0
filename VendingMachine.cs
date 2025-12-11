class VendingMachine
{
    public HashSet<uint> AcceptableCoinValues { get; init; }
    public Dictionary<uint, CoinStack> Coins { get; private set; }
    public List<ProductStack> Products { get; private set; }

    public uint Deposit => checked((uint)Coins.Sum(x => x.Value.TotalValue));

    public VendingMachine(HashSet<uint> AcceptableCoinValues)
    {
        this.AcceptableCoinValues = AcceptableCoinValues;
        Coins = new Dictionary<uint, CoinStack>();
        Products = new List<ProductStack>();
    }

    public void AddCoinStack(Coin Coin, uint Count)
    {
        if (!AcceptableCoinValues.Contains(Coin.Value))
            throw new ArgumentException(nameof(Coin.Value), "Coin.Value should be present in AcceptableCoinValues");
        if (Coins.ContainsKey(Coin.Value))
            throw new ArgumentException(nameof(Coin.Value), "Coin.Value is already presented in Coins keys");
        Coins[Coin.Value] = new CoinStack(Coin, Count);
    }

    public void AddCoins(uint Value, uint Count)
    {
        if (!AcceptableCoinValues.Contains(Value))
            throw new ArgumentException(nameof(Value), "Value should be present in AcceptableCoinValues");
        if (!Coins.TryGetValue(Value, out CoinStack coinStack))
            throw new ArgumentOutOfRangeException(nameof(Value), "Value should be present in Coins keys");
        coinStack.AddCoins(Count);
    }

    public void RemoveCoinStack(uint Value)
    {
        if (!Coins.ContainsKey(Value))
            throw new ArgumentOutOfRangeException(nameof(Value), "Value should be present in Coins keys");
        Coins.Remove(Value);
    }

    public void RemoveCoins(uint Value, uint Count)
    {
        if (!Coins.TryGetValue(Value, out CoinStack coinStack))
            throw new ArgumentOutOfRangeException(nameof(Value), "Value should be present in Coins keys");
        coinStack.RemoveCoins(Count);
    }

    public void AddProductStack(Product Product, uint Count)
    {
        Products.Add(new ProductStack(Product, Count));
    }

    public void AddProducts(int Id, uint Count)
    {
        if (Id >= Products.Count)
            throw new ArgumentOutOfRangeException(nameof(Id), "Id cannot be >= Products.Count");
        Products[Id].AddProducts(Count);
    }

    public void RemoveProductStack(int Id)
    {
        if (Id >= Products.Count)
            throw new ArgumentOutOfRangeException(nameof(Id), "Id cannot be >= Products.Count");
        Products.RemoveAt(Id);
    }

    public void RemoveProducts(int Id, uint Count)
    {
        if (Id >= Products.Count)
            throw new ArgumentOutOfRangeException(nameof(Id), "Id cannot be >= Products.Count");
        if (Count > Products[Id].Count)
            throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be > Products[Id].Count");
        if (Count == Products[Id].Count)
            Products.RemoveAt(Id);
        Products[Id].RemoveProducts(Count);
    }

    public override string ToString()
    {
        return $"Deposit {Deposit},\nProducts:\n\t{string.Join("\n\t", Products)}";
    }
}