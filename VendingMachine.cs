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

    public bool InsertCoin(int CoinValue){
        if (!AcceptableNominalsValues.Contains(CoinValue)){
            return false;
        } else {
            Deposit.Find(CoinStack => CoinStack.Nominal.Value == CoinValue).Count += 1;
            return true;
        }
    }

    public override string ToString() {
        return $"Deposit {Deposit.Sum(CoinStack => CoinStack.Value)}, Products: {Products}";
    }
}