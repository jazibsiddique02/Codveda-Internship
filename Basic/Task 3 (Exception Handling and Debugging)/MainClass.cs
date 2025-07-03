using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3__Exception_Handling_and_Debugging_
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("Jazib", 500);
            int toDeposit = 200;
            int toWithdraw = 200;

            //using Serilog for error tracking
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/task3.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Console.WriteLine($"Your current balance is {bankAccount.balance}");

            try
            {
                Console.WriteLine($"Welcome {bankAccount.Holder}");
                Console.WriteLine($"Attempting to Deposit {toDeposit}$.....");

                Console.WriteLine(bankAccount.Deposit(toDeposit));
            }
            catch(InvalidAmountException e)
            {
                Console.WriteLine();
                Log.Error($"{e.GetType().Name}: {e.Message}");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Transaction Completed.....");
            }


            Console.WriteLine();
            Console.WriteLine();

            try
            {
                Console.WriteLine($"Welcome {bankAccount.Holder}");
                Console.WriteLine();
                Console.WriteLine($"Attempting to Withdraw {toWithdraw}$.....");
                Console.WriteLine();
                Console.WriteLine(bankAccount.Withdraw(toWithdraw));

            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine();
                Log.Error($"{e.GetType().Name}: {e.Message}");

            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine();
                Log.Error($"{e.GetType().Name}: {e.Message}");

            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Transaction Completed....");
            }



        }
    }
}
