using System.Reflection;
using Gale.Files.Common.PpmduConfig;

namespace Gale.Files.Test.Ppmdu;

public class SupportedEditionsTest
{
    private Pmd2GameEdition[] supportedEditions;
    private Pmd2StringIndexData englishIndexData;

    [SetUp]
    public void Setup()
    {
        this.supportedEditions = Pmd2GameEdition.LoadSupportedEditions();
        this.englishIndexData = Pmd2StringIndexData.LoadFromGameEdition(
            this.supportedEditions.First(x => x.GameCode == "C2SE")
        );
    }

    [Test]
    public void Test1()
    {
        Assert.That(this.supportedEditions, Has.Length.EqualTo(5));
    }

    [Test]
    public void Test2()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.englishIndexData.Languages, Has.Length.EqualTo(1));
            Assert.That(this.englishIndexData.StringBlocks, Has.Length.EqualTo(175));
        });

    }
}
