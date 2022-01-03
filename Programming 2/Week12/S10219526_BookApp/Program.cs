using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace S10219526_BookApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            var res = await client.GetFromJsonAsync<BookResponseDto[]>(new Uri("https://ictonejourney.com/api/books"));
            if (res is null)
            {
                Console.WriteLine("Error in request");
                return;
            }

            Console.WriteLine($"{"ID",2} {"ISBN",13}  {"Title",-70}{"Author",-20}{"No. of Pages",15}{"Quantity",10}");
            foreach (var book in res)
            {
                Console.WriteLine(
                    $"{book.Id,2} {book.Isbn,13}  {book.Title,-70}{book.Author,-20}{book.Pages,15}{book.Qty,10}");
            }
        }
    }
}