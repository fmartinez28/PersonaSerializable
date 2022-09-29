using System.Text.Json;
namespace Library.Serialize;

public static class Serializer{
    public static string Serialize(object obj)
    {
        var settings = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true};
        string convertedJson = JsonSerializer.Serialize(obj, settings);
        return convertedJson;
    }
    public static T Deserialize<T>(string json){
        bool isNullOrEmpty = string.IsNullOrEmpty(json);
        if (!isNullOrEmpty){
            var settings = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true};
            T convertedT = JsonSerializer.Deserialize<T>(json, settings);
            return convertedT;
        }
        throw new Exception("El parámetro string no puede ser nulo o vacío");
    }
}