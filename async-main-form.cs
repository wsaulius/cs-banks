using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class MainForm : Form
    {
        private BankAccount checking;
        private BankAccount savings;

        public MainForm()
        {
            InitializeComponent();
            checking = new CheckingAccount("Alice", 500m);
            savings = new SavingsAccount("Bob", 5m);

            // Subscribe to BalanceChanged events
            checking.BalanceChanged += AccountBalanceChanged;
            savings.BalanceChanged += AccountBalanceChanged;

            // Initialize account info labels
            UpdateAccountInfo();
        }

        // Event handler for balance change
        private void AccountBalanceChanged(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        // Method to update account info labels
        private void UpdateAccountInfo()
        {
            lblCheckingInfo.Text = $"Checking Account: {checking.AccountHolder}, Balance: {checking.Balance:C}";
            lblSavingsInfo.Text = $"Savings Account: {savings.AccountHolder}, Balance: {savings.Balance:C}";
        }

        // Deposit for Checking Account using async/await
        private async void btnDepositChecking_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDepositAmount.Text, out decimal amount))
            {
                await DepositAsync(checking, amount);  // Simulate async deposit
                txtDepositAmount.Clear();
            }
            else
            {
                MessageBox.Show("Invalid deposit amount!");
            }
        }

        // Withdraw from Checking Account using async/await
        private async void btnWithdrawChecking_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtWithdrawAmount.Text, out decimal amount))
            {
                await WithdrawAsync(checking, amount);  // Simulate async withdrawal
                txtWithdrawAmount.Clear();
            }
            else
            {
                MessageBox.Show("Invalid withdrawal amount!");
            }
        }

        // Deposit for Savings Account using async/await
        private async void btnDepositSavings_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDepositAmount.Text, out decimal amount))
            {
                await DepositAsync(savings, amount);  // Simulate async deposit
                txtDepositAmount.Clear();
            }
            else
            {
                MessageBox.Show("Invalid deposit amount!");
            }
        }

        // Withdraw from Savings Account using async/await
        private async void btnWithdrawSavings_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtWithdrawAmount.Text, out decimal amount))
            {
                await WithdrawAsync(savings, amount);  // Simulate async withdrawal
                txtWithdrawAmount.Clear();
            }
            else
            {
                MessageBox.Show("Invalid withdrawal amount!");
            }
        }

        // Simulate an asynchronous deposit operation
        private Task DepositAsync(BankAccount account, decimal amount)
        {
            return Task.Run(() =>
            {
                Task.Delay(2000).Wait();  // Simulate some delay (like a network call)
                account.Deposit(amount);
            });
        }

        // Simulate an asynchronous withdrawal operation
        private Task WithdrawAsync(BankAccount account, decimal amount)
        {
            return Task.Run(() =>
            {
                Task.Delay(2000).Wait();  // Simulate some delay (like a network call)
                account.Withdraw(amount);
            });
        }

        // Handle dynamic type for deposit or withdrawal amount
        private void HandleDynamicDeposit(dynamic amount)
        {
            checking.Deposit(amount); // This works because 'dynamic' allows handling different types
            MessageBox.Show($"Deposited {amount:C} into Checking Account.");
        }

        // Perform an unsafe operation (pointer manipulation) in a struct
        private void btnUnsafeOperation_Click(object sender, EventArgs e)
        {
            unsafe
            {
                // Demonstrate unsafe code with pointers
                decimal amount = 100m;
                decimal* pAmount = &amount;
                *pAmount = 200m;  // Modify the value through pointer
                MessageBox.Show($"Unsafe operation: new amount = {amount:C}");
            }
        }

        // Using Nullable and ValueTuple
        private (decimal, string) GetWithdrawStatus(decimal amount)
        {
            if (amount <= 0)
                return (0, "Invalid withdrawal amount!");
            else
                return (amount, "Withdrawal successful.");
        }

        private void btnCheckWithdrawStatus_Click(object sender, EventArgs e)
        {
            var (amount, status) = GetWithdrawStatus(-50m); // Example with invalid amount
            MessageBox.Show(status);
        }

        // Demonstrate Boxing/Unboxing
        private void btnBoxingUnboxing_Click(object sender, EventArgs e)
        {
            object boxedAmount = 100m;  // Boxing
            decimal unboxedAmount = (decimal)boxedAmount;  // Unboxing
            MessageBox.Show($"Boxed and Unboxed amount: {unboxedAmount:C}");
        }

    }
}

