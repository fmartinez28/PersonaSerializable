namespace Library.Serialize;

interface ISerializable{
    public string Serialize();
    public T Deserialize<T>(string json);
}