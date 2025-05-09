using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Gale.Files.Common.PpmduConfig;

/// <summary>
/// Stores basic data for supported editions of Explorers of Sky.
/// </summary>
public sealed class Pmd2GameEdition
{
    /// <summary>
    /// Unique identifier for this version of the game.
    /// </summary>
    public string Id { get; private init; }

    /// <summary>
    /// The ROM's game code corresponding to the game version.
    /// </summary>
    public string GameCode { get; private init; }

    /// <summary>
    /// The region where the game was sold. Either "NorthAmerica", "Europe", or "Japan".
    /// </summary>
    public string Region { get; private init; }

    /// <summary>
    /// The 16bits value in the arm9.bin at offset 0x0E. It differs between games,
    /// and won't be modded, so its used to find out what games the files belong to.
    /// </summary>
    public ushort Arm9Magic { get; private init; }

    /// <summary>
    /// Default language to use when reading game files. For example Pokémon names
    /// will be read in english if this is "English".
    /// </summary>
    public string DefaultLanguage { get; private init; }

    private Pmd2GameEdition() { }

    /// <summary>
    /// Loads the game editions supported by this library.
    /// </summary>
    /// <returns></returns>
    public static Pmd2GameEdition[] LoadSupportedEditions()
    {
        // Read the embedded YAML from this assembly.
        string yamlContent = EmbeddedResourceReader.ReadResource(
            "Gale.Files._resources.ppmdu_config.supported_games.yaml"
        );

        IDeserializer deserializer = new DeserializerBuilder().Build();

        List<YamlDataModel> dataModel = deserializer.Deserialize<List<YamlDataModel>>(yamlContent);
        return [.. dataModel.Select(
            dataModel =>
                new Pmd2GameEdition
                {
                    Id = dataModel.Id,
                    GameCode = dataModel.GameCode,
                    Region = dataModel.Region,
                    Arm9Magic = dataModel.Arm9Magic,
                    DefaultLanguage = dataModel.DefaultLanguage
                }
            )
        ];
    }

    private sealed class YamlDataModel
    {
        [YamlMember(Alias = "id")]
        public string Id { get; set; }

        [YamlMember(Alias = "gameCode")]
        public string GameCode { get; set; }

        [YamlMember(Alias = "region")]
        public string Region { get; set; }

        [YamlMember(Alias = "arm9Magic")]
        public ushort Arm9Magic { get; set; }

        [YamlMember(Alias = "defaultLanguage")]
        public string DefaultLanguage { get; set; }
    }
}
