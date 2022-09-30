using Library;
using Library.Serialize;
namespace Library.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CorrectSerialization()
    {
        Persona myself = new("53686906", "Facundo", new DateTime(2002, 10, 28));
        var actual = myself.Serialize(); 
        string expected = "{\r\n  \"Cedula\": \"53686906\",\r\n  \"Nombre\": \"Facundo\",\r\n  \"FechaNacimiento\": \"2002-10-28T00:00:00\"\r\n}";
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]

    public void CatchNullParam(){
        Assert.Catch<ArgumentException>(NullDeserializerParam);
    }
    public void NullDeserializerParam(){
        Persona newPerson = Persona.use.Deserialize("");        //Tira excepción porque Deserialize no toma params vacíos/nulos
    }
}