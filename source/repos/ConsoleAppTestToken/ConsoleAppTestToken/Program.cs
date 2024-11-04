using Newtonsoft.Json.Linq;
using System;

public class Program
{
    public static void Main()
    {
        // Example JSON response
        string jsonResponse = @"{
          ""token"": ""3cdc64a0-cb3d-4a8f-ac24-48e5a5665892"",
          ""nickName"": ""1"",
          ""expirationTime"": ""2024-09-09T21:23:20.6415489+03:00""
        }";

        // Parse JSON using JObject
        JObject json = JObject.Parse(jsonResponse);

        // Extract the token
        string token = json["token"].ToString();
        Console.WriteLine($"Extracted token: {token}");
    }
}
