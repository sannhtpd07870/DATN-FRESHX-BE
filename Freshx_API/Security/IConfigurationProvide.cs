using Microsoft.Extensions.Configuration;
using Freshx_API.Helpers;
using System;
using System.Collections.Generic;
using System.Text.Json;

public class EncryptedConfigurationProvider : ConfigurationProvider
{
    private readonly string _password;
    private readonly byte[] _salt;

    public EncryptedConfigurationProvider(string password, byte[] salt)
    {
        _password = password;
        _salt = salt;
    }

    public override void Load()
    {
        var key = EncryptionHelper.GenerateKey(_password, _salt);
        var json = System.IO.File.ReadAllText("appsettings.json");
      
        var config = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        
        ProcessElement(config, "", key);
    }

    private void ProcessElement(JsonElement element, string prefix, byte[] key)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    ProcessElement(property.Value, string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}:{property.Name}", key);
                }
                break;
            case JsonValueKind.Array:
                int index = 0;
                foreach (var item in element.EnumerateArray())
                {
                    ProcessElement(item, $"{prefix}:{index}", key);
                    index++;
                }
                break;
            case JsonValueKind.String:
                string value = element.GetString();
                if (!string.IsNullOrEmpty(value))
                {
                    string decryptedValue = EncryptionHelper.Decrypt(value, key);
                    Data[prefix] = decryptedValue;
                    Console.WriteLine($"Giá trị cho {prefix}: {decryptedValue}");
                }
                break;
            default:
                Data[prefix] = element.GetRawText();
                break;
        }
    }

    private void ProcessElement(Dictionary<string, JsonElement> config, string prefix, byte[] key)
    {
        foreach (var kvp in config)
        {
            ProcessElement(kvp.Value, string.IsNullOrEmpty(prefix) ? kvp.Key : $"{prefix}:{kvp.Key}", key);
        }
    }
}
