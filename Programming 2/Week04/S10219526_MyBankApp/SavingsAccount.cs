namespace S10219526_MyBankApp
{
    public class SavingsAccount : BankAccount
    {
        private double Rate { get; set; }

        public static string InterestHeader =>
            $"{"Acc No",-10}{"Acc Name",-15}{"Balance",-15}{"Rate",-10}{"Interest",-10}";

        public SavingsAccount()
        {
        }

        public SavingsAccount(string accNo, string accName, double balance, double rate)
        {
            AccNo = accNo;
            AccName = accName;
            Balance = balance;
            Rate = rate;
        }

        public double CalculateInterest()
        {
            return Balance * Rate / 100;
        }

        public override string ToString()
        {
            return $"AccNo: {AccNo} Acc Name: {AccName} Balance: {Balance} Rate: {Rate}";
        }

        public string ToStringWithInterest()
        {
            return $"{AccNo,-10}{AccName,-15}{Balance,-15:F2}{Rate,-10:N2}{CalculateInterest(),-10:N2}";
        }
    }
}