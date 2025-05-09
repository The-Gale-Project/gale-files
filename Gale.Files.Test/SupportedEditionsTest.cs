using System.Reflection;
using Gale.Files.Common.PpmduConfig;

namespace Gale.Files.Test;

public class SupportedEditionsTest
{
    private Pmd2GameEdition[] supportedEditions;

    [SetUp]
    public void Setup()
    {
        this.supportedEditions = Pmd2GameEdition.LoadSupportedEditions();
    }

    [Test]
    public void Test1()
    {
        Assert.That(this.supportedEditions, Has.Length.EqualTo(5));
    }
}
