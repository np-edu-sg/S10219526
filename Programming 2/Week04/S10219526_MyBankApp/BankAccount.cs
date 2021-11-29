namespace S10219526_MyBankApp
{
    public class BankAccount
    {
        public string AccNo { get; set; }
        public string AccName { get; set; }
        public double Balance { get; set; }

        public BankAccount()
        {
        }

        public BankAccount(string accNo, string accName, double balance)
        {
            AccNo = accNo;
            AccName = accName;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > Balance) return false;
            Balance -= amount;
            return true;
        }

        public override string ToString()
        {
            return $"AccNo: {AccNo} Acc Name: {AccName} Balance: {Balance}";
        }
    }
}