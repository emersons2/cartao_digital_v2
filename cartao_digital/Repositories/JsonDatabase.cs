using Newtonsoft.Json;

public class JsonDatabase<T>
{
    private string _filePath => $"{typeof(T).Name.ToLower()}.json";

    public List<T> GetData()
    {
        if (!File.Exists(_filePath)) return new List<T>();
        var json = File.ReadAllText(_filePath);
        
        return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
    }

    public void SaveChanges(List<T> entities)
    {
        var json = JsonConvert.SerializeObject(entities);
        File.WriteAllText(_filePath, json);
    }
}