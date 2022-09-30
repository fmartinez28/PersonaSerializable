using Library;
using Library.Serialize;
using System.Text.Json;

namespace Program;

public class Programs{
    public static void Main(){
        Persona alguien = new("53686906", "Alguien", new DateTime(2000, 10, 12));
        var output = alguien.Serialize();
        Console.WriteLine(output);
        var alguno = Persona.use.Deserialize(output);
        Console.WriteLine(alguno.Cedula);
    }
}