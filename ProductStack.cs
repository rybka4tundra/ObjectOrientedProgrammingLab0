class ProductStack
{
    private Product _product;
    private int _count;

    public ProductStack(string ProductName, int ProductPrice, int ProductCount) {
        _product = new Product(ProductName, ProductPrice);
        _count = ProductCount;
    }

    public override string ToString() {
        return $"Product: {_product}, Count: {_count}";
    }
}