class Coin
{
    public uint Value { get; private set; }

    public Coin(uint Value)
    {
        if (Value == 0)
            throw new ArgumentOutOfRangeException(nameof(Value), "Value cannot be zero.");
        this.Value = Value;
    }

    public override string ToString()
    {
        return $"Value: {Value}";
    }
}