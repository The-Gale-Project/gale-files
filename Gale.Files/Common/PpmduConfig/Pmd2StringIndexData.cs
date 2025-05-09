using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Gale.Files.Common.PpmduConfig;

/// <summary>
/// Holds language and localized string data.
/// </summary>
public sealed class Pmd2StringIndexData
{
    /// <summary>
    /// The available languages in this edition of the game.
    /// </summary>
    public Pmd2Language[] Languages { get; private init; }

    /// <summary>
    /// The blocks of strings held by this edition of the game.
    /// </summary>
    public Pmd2StringBlock[] StringBlocks { get; private init; }

    private Pmd2StringIndexData() { }

    /// <summary>
    /// Load the language data from a supported edition of the game.
    /// </summary>
    /// <param name="gameEdition">The edition of the game to retrieve the data from.</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static Pmd2StringIndexData LoadFromGameEdition(Pmd2GameEdition gameEdition)
    {
        string yamlResourcePath = gameEdition.GameCode switch
        {
            "C2SE" => "Gale.Files._resources.ppmdu_config.strings.eos_na_strings.yaml",
            "C2SP" => "Gale.Files._resources.ppmdu_config.strings.eos_eu_strings.yaml",
            "C2SJ" => "Gale.Files._resources.ppmdu_config.strings.eos_eu_strings.yaml",
            _ => throw new NotSupportedException("This edition of the game is not supported.")
        };

        string yamlData = EmbeddedResourceReader.ReadResource(yamlResourcePath);

        IDeserializer deserializer = new DeserializerBuilder().Build();

        YamlDataModel dataModel = deserializer.Deserialize<YamlDataModel>(yamlData);

        return new Pmd2StringIndexData
        {
            Languages = [.. dataModel.Languages.Select(
                x => new Pmd2Language(x.Name, x.FileName, x.Locale, x.M2N, x.N2M, x.I2N)
            )],
            StringBlocks = [.. dataModel.StringBlocks.Select(
                x => new Pmd2StringBlock(x.Name, x.Begin, x.End)
            ).ToArray()]
        };
    }

    private sealed class YamlDataModel
    {
        [YamlMember(Alias = "Languages")]
        public List<LanguageDataModel> Languages { get; set; }

        [YamlMember(Alias = "StringBlocks")]
        public List<StringBlockDataModel> StringBlocks { get; set; }

        public sealed class LanguageDataModel
        {
            [YamlMember(Alias = "name")]
            public string Name { get; set; }

            [YamlMember(Alias = "filename")]
            public string FileName { get; set; }

            [YamlMember(Alias = "locale")]
            public string Locale { get; set; }

            [YamlMember(Alias = "m2n")]
            public string M2N { get; set; }

            [YamlMember(Alias = "n2m")]
            public string N2M { get; set; }

            [YamlMember(Alias = "i2n")]
            public string I2N { get; set; }
        }

        public sealed class StringBlockDataModel
        {
            [YamlMember(Alias = "name")]
            public string Name { get; set; }

            [YamlMember(Alias = "beg")]
            public int Begin { get; set; }

            [YamlMember(Alias = "end")]
            public int End { get; set; }
        }
    }
}
