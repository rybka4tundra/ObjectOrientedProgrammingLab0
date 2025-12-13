public class Product
{
    public string Name { get; private set; }
    public uint Price { get; private set; }

    public Product(string Name, uint Price)
    {
        if (Name == "")
            throw new ArgumentOutOfRangeException(nameof(Name), "Name cannot be empty.");
        if (Price == 0)
            throw new ArgumentOutOfRangeException(nameof(Price), "Price cannot be zero.");
        this.Name = Name;
        this.Price = Price;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
}