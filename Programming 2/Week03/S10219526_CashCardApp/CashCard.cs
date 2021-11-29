namespace S10219526_CashCardApp
{
    public class CashCard
    {
        public string Id { get; private set; }
        public double Balance { get; private set; }

        public static string Header => $"{"Id",-5}{"Balance",-10}";

        public CashCard()
        {
        }

        public CashCard(string id, double balance)
        {
            Id = id;
            Balance = balance;
        }

        public void TopUp(double amount)
        {
            Balance += amount;
        }

        public bool Deduct(double amount)
        {
            if (amount > Balance) return false;

            Balance -= amount;
            return true;
        }

        public override string ToString()
        {
            return $"{Id,-5}{Balance,-10}";
        }
    }
}