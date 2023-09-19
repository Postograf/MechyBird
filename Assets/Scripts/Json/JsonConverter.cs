using System.IO;
using System.Threading.Tasks;

using UnityEngine;

public class JsonConverter<T>
{
    private string _path;

    public JsonConverter(string path)
    {
        _path = path;
    }

    public async void Serialize(T data, bool prettyPrint)
    {
        using (var writer = new StreamWriter(_path))
        {
            await writer.WriteAsync(JsonUtility.ToJson(data, prettyPrint));
        }
    }

    public async Task<T> Deserialize(T @default = default)
    {
        if (File.Exists(_path) == false)
            return @default;

        using (var reader = new StreamReader(_path))
        {
            var text = await reader.ReadToEndAsync();
            return JsonUtility.FromJson<T>(text);
        }
    }
}