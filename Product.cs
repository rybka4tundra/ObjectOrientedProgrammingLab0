class Product
{
    private string _name;
    private int _price;
    public Product(string ProductName, int ProductPrice){
        _name = ProductName;
        _price = ProductPrice;
    }

    public override string ToString() {
        return $"Name: {_name}, Price: {_price}";
    }
}