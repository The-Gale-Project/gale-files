namespace Gale.Files.DungeonData.MappaBin;

/// <summary>
/// Represents the structure of a dungeon floor.
/// </summary>
public enum FloorStructure : byte
{
    /// <summary>
    /// Medium-Large (Max: 6 x 4).
    /// </summary>
    MediumLargeA = 0x00,

    /// <summary>
    /// Small (Max: 2 x 3).
    /// </summary>
    Small = 0x01,

    /// <summary>
    /// Single room which is a monster house.
    /// </summary>
    SingleRoomMonsterHouse = 0x02,

    /// <summary>
    /// Outer ring with 8 small rooms inside in a 4 x 2 shape.
    /// </summary>
    OuterRing = 0x03,

    /// <summary>
    /// Crossroads (3 rooms at the top, 3 at the bottom, 2 on each side).
    /// </summary>
    Crossroads = 0x04,

    /// <summary>
    /// Two rooms, one is a monster house.
    /// </summary>
    TwoRooms = 0x05,

    /// <summary>
    /// Line (1 horizontal line with 5 rooms in a row).
    /// </summary>
    Line = 0x06,

    /// <summary>
    /// Cross (5 rooms: up, down, left, right, center).
    /// </summary>
    Cross = 0x07,

    /// <summary>
    /// Small-Medium (Max: 4 x 2)
    /// </summary>
    SmallMediumA = 0x08,

    /// <summary>
    /// Beetle (1 big room in the center with 3 rooms on each side.
    /// </summary>
    Beetle = 0x09,

    /// <summary>
    /// Outer rooms (All the rooms are in the map borders, none in the center)
    /// (Max: 6 x 4).
    /// </summary>
    OuterRooms = 0x0A,

    /// <summary>
    /// Small-Medium (Max: 3 x 3).
    /// </summary>
    SmallMediumB = 0x0B,

    /// <summary>
    /// Medium-Large (Max: 6 x 4).
    /// </summary>
    MediumLargeB = 0x0C,

    /// <summary>
    /// Medium-Large (Max: 6 x 4).
    /// </summary>
    MediumLargeC = 0x0D,

    /// <summary>
    /// Medium-Large (Max: 6 x 4).
    /// </summary>
    MediumLargeD = 0x0E,

    /// <summary>
    /// Medium-Large (Max: 6 x 4).
    /// </summary>
    MediumLargeE = 0x0F,
}
