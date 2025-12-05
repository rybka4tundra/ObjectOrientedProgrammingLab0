class VendingMachine
{
    private List<int> AcceptableNominalsValues {get; set;}
    private List<CoinStack> Deposit {get; set;}
    private List<ProductStack> Products {get; set;}

    public VendingMachine() {
        AcceptableNominalsValues = new List<int> {1,2,5,10};
        Deposit = AcceptableNominalsValues.Select(value => new CoinStack(new Coin(value), 0)).ToList();
        Products = new List<ProductStack>();
    }

    public int DepositValue{
        get => Deposit.Sum(CoinStack => CoinStack.Value);
    }

    //TODO Make in CoinStack Coin a private value and Count also
    public bool InsertCoin(int CoinValue){
        if (!AcceptableNominalsValues.Contains(CoinValue)){
            return false;
        } else {
            Deposit.Find(CoinStack => CoinStack.Nominal.Value == CoinValue).Count += 1;
            return true;
        }
    }

    public void AddProductStack(string productName, int productPrice, int productCount) {
        Products.Add(new ProductStack(productName, productPrice, productCount));

    }

    public int Collect(){
        int income = this.DepositValue;
        Deposit.Clear();
        return income;
    }

    public override string ToString() {
        return $"Deposit {Deposit.Sum(CoinStack => CoinStack.Value)},\nProducts:\n\t{string.Join("\n\t", Products)}";
    }
}