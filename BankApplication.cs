using system;

public class BankAccount{

    public string CustomerName { get; set; }
    public int AccountNumber {get; set; }
    private static int AccountNumberNotSupplied = 100000;
    public decimal Balance {get; set; }

    public BankAccount(string inputName, int inputNumber){
        CustomerName = inputName;
        AccountNumber = inputNumber;
    }

    public BankAccount(string inputName){
        CustomerName = inputName;
        AccountNumber = AccountNumberNotSupplied;
    }

    public void Deposit(decimal amount){
        if (amount < 0){
            throw new ArgumentException("Deposit amount must be more than 0")
        }
        Balance += amount;
    }

    public void Withdraw(decimal amount){
        if (amount < 0){
            throw new ArgumentException("Withdrawal amount must be positive")
        }
        if (Balance < amount){
            throw new InvalidOperationExeption("Insufficient funds available")
        }
        Balance -+ amount;
    }

}