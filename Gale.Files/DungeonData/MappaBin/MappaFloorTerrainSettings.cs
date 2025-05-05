namespace Gale.Files.DungeonData.MappaBin;


/// <summary>
/// Loads the mappa floor terrain bitflags from the associated byte.
/// </summary>
/// <param name="bitFlag">Byte that stores the terrain bitflags.</param>
public readonly struct MappaFloorTerrainSettings(byte bitFlag)
{
    /// <summary>
    /// True if the floor has secondary terrain, otherwise false.
    /// </summary>
    public bool HasSecondaryTerrain { get; } = Convert.ToBoolean(bitFlag >> 0 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk1 { get; } = Convert.ToBoolean(bitFlag >> 1 & 1);

    /// <summary>
    /// True if the floor should generate imperfect rooms, otherwise false.
    /// </summary>
    public bool GenerateImperfectRooms { get; } = Convert.ToBoolean(bitFlag >> 2 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk3 { get; } = Convert.ToBoolean(bitFlag >> 3 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk4 { get; } = Convert.ToBoolean(bitFlag >> 4 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk5 { get; } = Convert.ToBoolean(bitFlag >> 5 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk6 { get; } = Convert.ToBoolean(bitFlag >> 6 & 1);

    /// <summary>
    /// UNK: This flag does not have a known purpose currently.
    /// </summary>
    public bool Unk7 { get; } = Convert.ToBoolean(bitFlag >> 7 & 1);

    /// <summary>
    /// Byte used to calculate the flags used in the extra terrain settings.
    /// </summary>
    public byte BitFlag { get; } = bitFlag;
}
