using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {

        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://api.gameofthronesquotes.xyz/v1/random"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode resultsNode = JsonNode.Parse(response)!;
        // Console.WriteLine(characterNode);
        JsonNode sentenceNode = resultsNode!["sentence"]!;
        JsonNode characterNode = resultsNode!["character"]!;
        JsonNode houseNode = resultsNode!["house"]!;
        Console.WriteLine("");
        Console.WriteLine(characterNode + ": " + sentenceNode + " " + houseNode);
        Console.WriteLine("\nDone.");
    }
}