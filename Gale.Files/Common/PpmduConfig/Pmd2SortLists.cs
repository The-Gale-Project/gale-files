namespace Gale.Files.Common.PpmduConfig;


/// <summary>
/// Stores the names of the files used to sort things in in-game lists.
/// </summary>
public sealed class Pmd2SortLists
{
    /// <summary>
    /// NEEDS INFO: The exact use of this file is not documented.
    /// </summary>
    public string M2N { get; }

    /// <summary>
    /// NEEDS INFO: The exact use of this file is not documented.
    /// </summary>
    public string N2M { get; }

    /// <summary>
    /// NEEDS INFO: The exact use of this file is not documented.
    /// </summary>
    public string I2N { get; }

    internal Pmd2SortLists(string m2n, string n2m, string i2n)
    {
        this.M2N = m2n;
        this.N2M = n2m;
        this.I2N = i2n;
    }
}
