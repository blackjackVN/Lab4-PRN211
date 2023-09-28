namespace Lab4bai2
{
    public delegate void BalanceChangedEventHandler(decimal newBalance);

    public class Account
    {
        private decimal balance;

        public event BalanceChangedEventHandler BalanceChanged;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnBalanceChanged(balance);
            }
        }

        protected virtual void OnBalanceChanged(decimal newBalance)
        {
            BalanceChanged?.Invoke(newBalance);
        }
    }


    public class Banking
    {
        
            public static void Main()
            {
                Account user = new Account();
                user.BalanceChanged += BalanceChangedHandler;
                user.Balance = 100;
                user.Balance = 200;
                Console.ReadLine();
            }

            private static void BalanceChangedHandler(decimal newBalance)
            {
                string formattedBalance = newBalance.ToString("F2");
                Console.WriteLine("New balance: " + formattedBalance);
            }
        }


    
}