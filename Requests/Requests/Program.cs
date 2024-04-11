using System.Text.Json.Serialization;

var client = new RestClient(new Uri("https://api.coingecko.com/api/v3"));
var req = new RestRequest("simple/price?ids=bitcoin&vs_currencies=GBP%2CUSD");
var resp = await client.GetAsync<Root>(req);

Console.WriteLine("Current BTC Price:");
Console.WriteLine($"GBP : £{resp.Bitcoin.Gbp}");
Console.WriteLine($"EUR : €{resp.Bitcoin.Eur}");

internal class Bitcoin 
{
    [JsonPropertyName("gbp")] public double Gbp { get; set; }
    [JsonPropertyName("eur")] public double Eur { get; set; } 
}

internal class Root
{
    [JsonPropertyName("bitcoin")] public Bitcoin Bitcoin { get; set; }
}