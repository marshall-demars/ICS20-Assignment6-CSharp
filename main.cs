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
        Console.WriteLine(jsonAsDictionary);
        JsonNode resultsNode = JsonNode.Parse(response)!;
        // Console.WriteLine(sentenceNode);
        JsonNode sentenceNode = resultsNode!["sentence"]!;
        // Console.WriteLine(nameNode);
        JsonNode characterNode = resultsNode!["nameNode"]!;
        // Console.WriteLine(houseNode);
        JsonNode houseNode = resultsNode!["house"]!;
        Console.WriteLine("");
        Console.WriteLine(characterNode + ": " + sentenceNode + " " + houseNode);
        Console.WriteLine("\nDone.");
    }
}