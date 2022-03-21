using System.Text.Json;

namespace App.Helpers
{
    public static class JsonHelper
    {
        public static void SaveInJson(string name, object list)
        {
            string json = JsonSerializer.Serialize(list);
            System.IO.File.WriteAllText($"src/store/{name}.json", json);
        }
    }
}