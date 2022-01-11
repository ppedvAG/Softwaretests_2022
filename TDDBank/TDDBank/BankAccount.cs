namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal value)
        {
            if(value <= 0)
                throw new ArgumentException("value");

            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("value");
            if(value > Balance)
                throw new InvalidOperationException("Out of Money");

            Balance -= value;

        }
    }
}