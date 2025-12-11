class CoinStack
{
    public Coin Coin { get; private set; }
    public uint Count { get; private set; }

    public uint TotalValue => Coin.Value * Count;

    public CoinStack(Coin Coin, uint Count)
    {
        if (Count == 0)
            throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be zero.");
        this.Coin = Coin;
        this.Count = Count;
    }

    public void AddCoins(uint Count)
    {
        this.Count += Count;
    }

    public void RemoveCoins(uint Count)
    {
        if (Count >= this.Count)
            throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be >= this.Count.");
        this.Count -= Count;
    }

    public override string ToString()
    {
        return $"Coin: {Coin}, Count: {Count}";
    }
}