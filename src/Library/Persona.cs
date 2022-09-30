using System;
using System.Text.Json;
using Library.Serialize;

namespace Library;

//Utilizando la solución de Persona.cs provista en Teams como base
public class Persona : ISerializer<Persona>{
    public static string cedulaReferencia = "2987634";
    public static readonly Persona use = new("53686906", "Nombre", new(2000, 02, 20));  //Implemento para utilizar con Deserialize
    public string Serialize()
    {
        var settings = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true};
        string convertedJson = JsonSerializer.Serialize(this, settings);
        return convertedJson;
    }
    public Persona Deserialize(string json){                            //Me gustaría tener Deserialize como un método estático
        bool isNullOrEmpty = string.IsNullOrEmpty(json);                //pero no pude resolver cómo lograrlo implementando una interfaz
        if (!isNullOrEmpty){                                            //creo que en ese punto, una interfaz no sería lo más
            var convertedT = JsonSerializer.Deserialize<Persona>(json); //efectivo
            return convertedT;
        }
        throw new ArgumentException("El parámetro string no puede ser nulo o vacío");
    }
    // private string cedula;
    // private string nombre;
    // private DateTime fechaNacimiento;
    private string cedula = "";
    public string Cedula {
        get{
            return this.cedula;
        }
        set{
            bool condition = Persona.IsCedulaValida(value);
            if (condition)
            this.cedula = value.Replace(".", "").Replace("-","").Replace("/","").Replace(" ","");
        }
    }                //TODO Fixear el problema de las properties en vez de atributos privados para el JsonSerializer
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}

    public Persona(string cedula, string nombre, DateTime fechaNacimiento) {
        Cedula = cedula; //TODO ¿ Porque pusimos .SetCedula en vez de .Cedula ?
        Nombre = nombre;
        FechaNacimiento = fechaNacimiento;
    }
    /*
    public string GetCedula() {
        return this.cedula;
    }

    public void SetCedula(string cedula) { 
        if (Persona.IsCedulaValida(cedula)) {
            this.cedula = cedula.Replace(".", "").Replace("-","").Replace("/","").Replace(" ","");  //Esto queda "repetido", se podría optimizar.
        }
    }
    
    public string GetNombre() {
        return this.nombre;
    }
    public void SetNombre(string nombre) {
        this.nombre = nombre;
    }
    
    public DateTime GetFechaNacimiento(){
        return this.fechaNacimiento;
    }

    public void SetFechaNacimiento(DateTime fecha) {
        this.fechaNacimiento = fecha;
    }
    */
    public int GetEdad() {  //TODO hacerlo en menos líneas ¿sin cargar variable edad ? ¿sin variable hoy? Acortar if.
        DateTime hoy = DateTime.Today;
        int edad =  hoy.Year - this.FechaNacimiento.Year;
        if (hoy.Month < this.FechaNacimiento.Month || (hoy.Month == this.FechaNacimiento.Month && hoy.Day < this.FechaNacimiento.Day)){
            edad = edad - 1;
        }   //cuando la condición del if queda muy larga, personalmente no me gusta hacerlo en una única línea.
        return edad;
    }

    public static bool IsCedulaValida(string cedula){ //TODO Mostrar como acortar los if's
        // Quitar caracteres no numéricos
        cedula = cedula.Replace(".", "").Replace("-","").Replace("/","").Replace(" ","");   //Esto queda "repetido", se podría optimizar.
        
        long cedulaLong;
        if (cedula.Length != 8 || (!long.TryParse(cedula,out cedulaLong))) {
            return false;
        }
        // Calcular número verificador
        int checkSum = 0;
        for (int i = 0; i < Persona.cedulaReferencia.Length; i++){
            int digitoActual = Convert.ToInt32(cedula[i].ToString());
            int digitoReferenciaActual = Convert.ToInt32(Persona.cedulaReferencia[i].ToString());
            checkSum = checkSum + digitoActual * digitoReferenciaActual;
        }
        int digitoVerificador = 10 - (checkSum % 10);
        if (digitoVerificador == 10) {
            digitoVerificador = 0;
        }
        if (digitoVerificador == Convert.ToInt32(cedula[7].ToString())){
            return true;
        }
        return false;
    }
}