using System;
using System.Collections.Generic;
using System.Linq;

namespace S10219526_CashCardApp
{
    class Program
    {
        public static void InitCardList(List<CashCard> list)
        {
            list.Add(new CashCard("001", 25));
            list.Add(new CashCard("002", 25));
            list.Add(new CashCard("003", 30));
            list.Add(new CashCard("004", 30));
            list.Add(new CashCard("005", 50));
        }

        public static CashCard Search(List<CashCard> list, string id)
        {
            // foreach (var c in list)
            // {
            //     if (c.Id == id) return c;
            // }
            //
            // return null;
            return list.SingleOrDefault(c2 => c2.Id == id);
        }

        public static void Main(string[] args)
        {
            var cardList = new List<CashCard>();
            InitCardList(cardList);

            Console.WriteLine(CashCard.Header);
            cardList.ForEach(Console.WriteLine);

            Console.Write("Please input a cashcard ID: ");
            var input = Console.ReadLine();

            var card = Search(cardList, input);
            if (card is null)
            {
                Console.WriteLine("Cashcard was not found!");
            }
            else
            {
                Console.WriteLine($"Balance: {card.Balance}");
                double deduct;
                while (true)
                {
                    Console.Write("Please enter an amount to deduct: ");
                    if (double.TryParse(Console.ReadLine(), out deduct)) break;
                }

                Console.WriteLine($"Deduction successful: {card.Deduct(deduct)}");
                Console.WriteLine($"New balance: {card.Balance}");
            }
        }
    }
}