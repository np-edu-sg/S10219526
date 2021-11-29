using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Q2
{
    class Loan
    {
        public string Id { get; set; }
        public string BorrowerId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }

        public static string Header =>
            $"{"Book ID",-10}{"Borrower ID",-20}{"Date Borrowed",-20}{"Date Returned",-20}{"Days Loan",-20}{"Days Overdue",-20}{"Fine",-10}";

        public static string CsvHeader => "Book ID, Borrower ID, Days Overdue, Fine Amount";

        /// <summary>
        /// Accepts a line from CSV file
        /// </summary>
        /// <param name="line"></param>
        public Loan(string line)
        {
            var fields = line.Split(",");
            Id = fields[0];
            BorrowerId = fields[1];
            DateBorrowed = DateTime.Parse(fields[2]);
            DateReturned = DateTime.Parse(fields[3]);
        }

        public string ToCsv()
        {
            var daysOverdue = DateReturned - DateBorrowed;
            return $"\"{Id}\",\"{BorrowerId}\",\"{daysOverdue.Days - 14}\",\"{(daysOverdue.Days - 14) * 0.5}\"";
        }

        public override string ToString()
        {
            var daysLoan = DateReturned - DateBorrowed;
            var daysOverdue = "";
            if (daysLoan.Days > 14)
            {
                daysOverdue = (daysLoan.Days - 14).ToString();
            }

            var fine = "";
            if (daysOverdue != "")
            {
                fine = (int.Parse(daysOverdue) * 0.5).ToString("C2");
            }

            return
                $"{Id,-10}{BorrowerId,-20}{DateBorrowed,-20:dd/MM/yyyy}{DateReturned,-20:dd/MM/yyyy}{daysLoan.Days,-20}{daysOverdue,-20}{fine,-10}";
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var file = await File.ReadAllLinesAsync("./Assets/LoanInfo.csv");
            var loans = new List<Loan>();

            Console.WriteLine(Loan.Header);

            foreach (var line in file[1..])
            {
                var loan = new Loan(line);
                loans.Add(loan);
                Console.WriteLine(loan);
            }

            var overdueLoans = new List<Loan>();
            var overdueLoansString = new List<string>();
            foreach (var loan in loans)
            {
                if ((loan.DateReturned - loan.DateBorrowed).Days <= 14) continue;
                overdueLoans.Add(loan);
                overdueLoansString.Add(loan.ToCsv());
            }

            await File.WriteAllLinesAsync("./overdueinfo.csv", new[] { Loan.CsvHeader });
            await File.AppendAllLinesAsync("./overdueinfo.csv", overdueLoansString);

            Console.WriteLine($"{overdueLoans.Count} written to overdueinfo.csv");
        }
    }
}