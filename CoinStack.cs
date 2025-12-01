class CoinStack
{
    public Coin Nominal {get; set;}
    public int Count {get; set;}

    public CoinStack(Coin nominal, int count) {
        Nominal = nominal;
        Count = count; 
    }

    public int Value{
        get => Nominal.Value * Count;
    }
}