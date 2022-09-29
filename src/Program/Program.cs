using Library;
using Library.Serialize;
using System.Text.Json;

namespace Program;

public class Programs{
    public static void Main(){
        Persona alguien = new Persona("53686906", "Alguien", new DateTime(2000, 10, 12));
        var output = Serializer.Serialize(alguien);
        Console.WriteLine(output);
        Persona alguno = Serializer.Deserialize<Persona>(output);
        Console.WriteLine(alguno.GetCedula);
    }
}