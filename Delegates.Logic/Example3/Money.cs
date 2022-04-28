namespace Delegates.Logic.Example3
{
    public class Money
    {
        public decimal moneyValue { get; init; }
        
        public Money(decimal moneyValue)
        {
            this.moneyValue = moneyValue;
        }

        public static Money operator +(Money oldMoney, Money newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue + newMoney.moneyValue;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator +(Money oldMoney, decimal newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue + newMoney;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator -(Money oldMoney, Money newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue - newMoney.moneyValue;
            
            return new Money(resultMoneyValue);
        }
        
        public static Money operator -(Money oldMoney, decimal newMoney)
        {
            decimal resultMoneyValue = oldMoney.moneyValue - newMoney;
            
            return new Money(resultMoneyValue);
        }

        public static bool operator < (Money oldMoney, Money newMoney)
        {
            return oldMoney.moneyValue < newMoney.moneyValue;
        }

        public static bool operator >(Money oldMoney, Money newMoney)
        {
            return oldMoney.moneyValue > newMoney.moneyValue;
        }
    }
}