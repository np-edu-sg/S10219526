using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarParkAvailabilityApp
{
    public class CarParkResponseDto
    {
        [JsonPropertyName("items")] public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("carpark_data")] public List<CarparkData> CarparkDataList { get; set; }
    }

    public class CarparkData
    {
        [JsonPropertyName("carpark_info")] public List<CarparkInfo> CarparkInfoList { get; set; }
        [JsonPropertyName("carpark_number")] public string CarparkNumber { get; set; }
    }

    public class CarparkInfo
    {
        [JsonPropertyName("total_lots")] public int TotalLots { get; set; }
        [JsonPropertyName("lot_type")] public char LotType { get; set; }
        [JsonPropertyName("lots_available")] public int LotsAvailable { get; set; }
    }
}