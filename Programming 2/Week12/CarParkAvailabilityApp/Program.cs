using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarParkAvailabilityApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            var res = await client.GetFromJsonAsync<CarParkResponseDto>(
                new Uri("https://api.data.gov.sg/v1/transport/carpark-availability"));
            if (res is null)
            {
                Console.WriteLine("Error in request");
                return;
            }

            Console.WriteLine($"{"carpark_number",15}{"total_lots",15}{"lot_type",15}{"lots_available",15}");
            foreach (var item in res.Items[0].CarparkDataList)
            {
                Console.WriteLine(
                    $"{item.CarparkNumber,15}{item.CarparkInfoList[0].TotalLots,15}{item.CarparkInfoList[0].LotType,15}{item.CarparkInfoList[0].LotsAvailable,15}");
            }
        }
    }
}