using System;
using System.Text.Json;
using Library;
using Library.Serialize;
public class Program{
    public static void Main(){
        DateTime cosa = new(2000, 10, 20);
        Persona alguien = new("48544174", "Alguien", cosa);
        string output = alguien.Serialize();
        Console.WriteLine(output);

        Persona newAlguien = new(output.cedula, output.nombre, output.nacimiento);
    }
}