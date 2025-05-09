namespace Gale.Files.Common.PpmduConfig;

/// <summary>
/// Data for a set of strings within a language file.
/// </summary>
public sealed class Pmd2StringBlock
{
    /// <summary>
    /// Descriptive name of this block of strings.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The inclusive lower bounds of this block of strings.
    /// </summary>
    public int Begin { get; }

    /// <summary>
    /// The exclusive upper bounds of this block of strings.
    /// </summary>
    public int End { get; }

    internal Pmd2StringBlock(string name, int begin, int end)
    {
        this.Name = name;
        this.Begin = begin;
        this.End = end;
    }
}
