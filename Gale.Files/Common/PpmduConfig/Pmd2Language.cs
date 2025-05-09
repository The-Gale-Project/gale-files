namespace Gale.Files.Common.PpmduConfig;

/// <summary>
/// Stores the language data contained in each version of the game.
/// </summary>
public sealed class Pmd2Language
{
    /// <summary>
    /// Name of the language.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// File where the language data is stored.
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Locale of this language in BCP 47 language tag format (e.g. en-US for US English).
    /// </summary>
    public string Locale { get; }

    /// <summary>
    /// The sort lists this language uses.
    /// </summary>
    public Pmd2SortLists SortLists { get; }

    internal Pmd2Language(
        string name,
        string fileName,
        string locale,
        string m2n,
        string n2m,
        string i2n
    )
    {
        this.Name = name;
        this.FileName = fileName;
        this.Locale = locale;
        this.SortLists = new Pmd2SortLists(m2n, n2m, i2n);
    }
}
