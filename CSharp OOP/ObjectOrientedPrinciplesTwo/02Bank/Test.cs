using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02Bank
{
    class Test
    {
        static void Main()
        {
            //Test Loan
            Loan loanIndividual = new Loan(1000, 5, Account.Customer.Individual);
            Loan loanCompany = new Loan(1000, 5, Account.Customer.Company);
            Console.WriteLine("loanCompany.CalculateInterestAmount(3): " + loanCompany.CalculateInterestAmount(3));
            Console.WriteLine("loanIndividual.CalculateInterestAmount(4): " + loanIndividual.CalculateInterestAmount(4));
            Console.WriteLine("loanIndividual.CalculateInterestAmount(1): " + loanIndividual.CalculateInterestAmount(1));
            loanCompany.AddDeposit(500);
            Console.WriteLine("loanCompany.AddDeposit(500): " + loanCompany.Balance);
            loanIndividual.AddDeposit(500);
            Console.WriteLine("loanIndividual.AddDeposit(500): " + loanIndividual.Balance);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();

            //Test Deposit
            Deposit depositIndividual = new Deposit(1000, 5, Account.Customer.Individual);
            Deposit depositCompany = new Deposit(1000, 5, Account.Customer.Company);
            Console.WriteLine("depositCompany.CalculateInterestAmount(3): " + depositCompany.CalculateInterestAmount(3));
            Console.WriteLine("depositIndividual.CalculateInterestAmount(4): " + depositIndividual.CalculateInterestAmount(4));
            Console.WriteLine("depositIndividual.CalculateInterestAmount(1): " + depositIndividual.CalculateInterestAmount(1));
            depositCompany.AddDeposit(500);
            Console.WriteLine("depositCompany.AddDeposit(500): " + depositCompany.Balance);
            depositIndividual.AddDeposit(500);
            Console.WriteLine("depositIndividual.AddDeposit(500): " + depositIndividual.Balance);
            depositIndividual.WithDraw(400);
            Console.WriteLine("depositIndividual.WithDraw(400): " + depositIndividual.Balance);
            depositCompany.WithDraw(400);
            Console.WriteLine("depositCompany.WithDraw(400): " + depositCompany.Balance);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();

            //Test Mortage
            Mortage mortageIndividual = new Mortage(1000, 5, Account.Customer.Individual);
            Mortage mortageCompany = new Mortage(1000, 5, Account.Customer.Company);
            Console.WriteLine("mortageCompany.CalculateInterestAmount(3): " + mortageCompany.CalculateInterestAmount(3));
            Console.WriteLine("mortageIndividual.CalculateInterestAmount(4): " + mortageIndividual.CalculateInterestAmount(4));
            Console.WriteLine("moratgeIndividual.CalculateInterestAmount(1): " + mortageIndividual.CalculateInterestAmount(1));
            mortageCompany.AddDeposit(500);
            Console.WriteLine("mortageCompany.AddDeposit(500): " + mortageCompany.Balance);
            mortageIndividual.AddDeposit(500);
            Console.WriteLine("mortageIndividual.AddDeposit(500): " + mortageIndividual.Balance);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }
    }
}
 