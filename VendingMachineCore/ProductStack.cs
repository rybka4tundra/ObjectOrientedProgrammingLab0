public class ProductStack
{
    public Product Product { get; private set; }
    public uint Count { get; private set; }

    public uint TotalValue => Product.Price * Count;

    public ProductStack(Product Product, uint Count)
    {
        if (Count == 0)
            throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be zero.");
        this.Product = Product;
        this.Count = Count;
    }

    public void AddProducts(uint Count)
    {
        this.Count += Count;
    }

    public void RemoveProducts(uint Count)
    {
        if (Count >= this.Count)
            throw new ArgumentOutOfRangeException(nameof(Count), "Count cannot be >= this.Count.");
        this.Count -= Count;
    }

    public override string ToString()
    {
        return $"Product: {Product}, Count: {Count}";
    }
}