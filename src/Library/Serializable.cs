namespace Library.Serialize;

public interface ISerializer<T>{
    public string Serialize();
    public T Deserialize(string json);
}