using System;
using System.Linq;

namespace Aripov_Bahom_dasturlash_28_03_2026
{
    public class User
    {
        private string _name;
        private string _surname;
        private double _balance;
        private string _accountNumber;
        public User(string name, string surname, double balance, string accountNumber)
        {
            _name = name;
            _surname = surname;
            _balance = balance;
            _accountNumber = accountNumber;
        }
        public string Name => _name;
        public string Surname => _surname;

        public double Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
            }
        }
        public void UpdateBalance(double newBalance)
        {
            _balance = newBalance;
        }
    }
    public class BankService
    {
        public bool TryWithdraw(User user, double amount, out string message)
        {
            if (user.Balance >= amount)
            {
                user.UpdateBalance(user.Balance - amount);
                message = $"Balans muvaffaqiyatli yechildi.\nJoriy balansingiz: {user.Balance}";
                return true;
            }
            else
            {
                message = "Balans yetarli emas.";
                return false;
            }
        }

        public void ApplyBonus(ref double currentBalance)
        {
            if (currentBalance > 0)
            {
                currentBalance *= 1.05;
                Console.WriteLine("Bonus muvaffaqiyatli qo'shildi!");
            }
            else
            {
                Console.WriteLine("Balans yetarl emas, bonus berilmadi. ");
            }
        }
        public double CalculateTotal(params double[] prices)
        {
            return prices.Length > 0 ? prices.Sum() : 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Bahrim", "Aripov", 600000, "UZ123456");
            BankService service = new BankService();

            double jamiHarid = service.CalculateTotal(15000, 25000, 10000);
            Console.WriteLine($"Savatdagi jami summa: {jamiHarid} so'm");

            if (service.TryWithdraw(user1, jamiHarid, out string message))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
            }
            Console.ResetColor();

            double joriyBalans = user1.Balance;
            service.ApplyBonus(ref joriyBalans);
            user1.UpdateBalance(joriyBalans); 

            Console.WriteLine($"Bonusdan keyingi balans: {user1.Balance}");
        }
    }
}
