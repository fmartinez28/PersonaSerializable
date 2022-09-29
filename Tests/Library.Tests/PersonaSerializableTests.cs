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
    public void Test1()
    {
        Persona myself = new("53686906", "Facundo", new DateTime(28, 10, 2002));
        Assert.Pass();
    }
}