using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Gale.Files.DungeonData.MappaBin;

/// <summary>
/// Structure used to store mappa floor layout data.
/// </summary>
public readonly struct MappaFloorLayout : IEquatable<MappaFloorLayout>
{
    /// <summary>
    /// The structure of the floor.
    /// </summary>
    public FloorStructure Structure { get; }

    /// <summary>
    /// The density of the rooms on the floor.
    /// The game randomly adds a number between 0 
    /// and 2 to obtain the final value.
    /// </summary>
    public sbyte RoomDensity { get; }

    /// <summary>
    /// The ID of the tileset to be used for this floor.
    /// </summary>
    public byte TilesetId { get; }

    /// <summary>
    /// The ID of the music to play, based on a separate table 
    /// than the main music table.
    /// </summary>
    /// <remarks>
    /// The "music" value in a floor's data entry is used to address a table located at 0x22C5EB4 
    /// ([EU]overlay_0010.bin:0x8AF4 / [US]overlay_0010.bin:0x8ADC). Each entry is 2 bytes long, and can represent two things:
    /// If the highest bit is 0, it's the ID of the song that plays in the floor.
    /// If the highest bit is 1, the rest are used as an index to address a table 
    /// that starts at 0x22C5B54 ([EU]overlay_0010.bin:0x8794 / [US]overlay_0010.bin:0x877C). 
    /// It contains 30 rows, each one contains 4 entries, each entry is 2 bytes long. 
    /// The index is used to select a row, then one of the four entries inside the row is chosen at random. 
    /// The value of the chosen entry is the ID of the song that will play in the floor. This is used in 
    /// floors where the music isn't fixed.
    /// </remarks>
    public byte MusicId { get; }

    /// <summary>
    /// The weather that will occur on this floor.
    /// </summary>
    public FloorWeather Weather { get; }

    /// <summary>
    /// Amount of connections between cells that will be generated
    /// when the map is first created. More connections are added
    /// later to ensure that all the rooms can be accessed.
    /// </summary>
    /// <remarks>
    /// Minimum 1, if 0 then the generation fails and falls back
    /// to <see cref="FloorStructure.SingleRoomMonsterHouse"/>.
    /// </remarks>
    public byte FloorConnectivity { get; }

    /// <summary>
    /// Initial enemy density.
    /// </summary>
    public sbyte InitialEnemyDensity { get; }

    /// <summary>
    /// Chance that a shop will spawn on this floor.
    /// </summary>
    public byte KecleonShopChance { get; }

    /// <summary>
    /// Chance that a monster house will spawn on this floor.
    /// </summary>
    public byte MonsterHouseChance { get; }

    /// <summary>
    /// Varies between 0 and 1 on every floor, but it's not a flag.
    /// It's actually a 0-1% chance. If the chance passes, the game
    /// checks a value that will be between 0 and 9. If it's positive,
    /// nothing happens. So this chance value will never have any effect.
    /// </summary>
    /// <remarks>
    /// If the relevant patch is applied, this is the chance that a random 
    /// room will be a maze of wall tiles.
    /// </remarks>
    public byte UnusedChance { get; }

    /// <summary>
    /// Chance that an item will spawn sticky.
    /// </summary>
    public byte StickyItemChance { get; }

    /// <summary>
    /// True if dead ends are allowed on the floor, otherwise false.
    /// </summary>
    public bool DeadEnds { get; }

    /// <summary>
    /// If greater than 0, rooms on the floor will spawn with secondary
    /// terrain (water, lava, void).
    /// </summary>
    public byte SecondaryTerrain { get; }

    /// <summary>
    /// Set of bitflags used to control extra terrain settings.
    /// </summary>
    public MappaFloorTerrainSettings TerrainSettings { get; }

    /// <summary>
    /// UNK: This seems to be unused.
    /// </summary>
    public bool UnkE { get; }

    /// <summary>
    /// The density of items spawned on the floor map.
    /// </summary>
    public byte ItemDensity { get; }

    /// <summary>
    /// Density of traps on the floor, calculated randomly between
    /// <see cref="TrapDensity"/> / 2 and <see cref="TrapDensity"/>
    /// </summary>
    public byte TrapDensity { get; }

    /// <summary>
    /// The number of this floor.
    /// </summary>
    public byte FloorNumber { get; }

    /// <summary>
    /// ID of the fixed floor or floor fragment of this floor.
    /// This includes key chambers, boss battle rooms, final rooms, etc.
    /// </summary>
    public byte FixedFloorId { get; }

    /// <summary>
    /// Used to generate additional hallways in the map (those "donuts" 
    /// that lead to nowhere, multiple entrances to the same room, 
    /// room exits connected to the same room, those dead ends that 
    /// come out of a room,  make a couple of twists and also lead to nowhere).
    /// </summary>
    public byte ExtraHallwayDensity { get; }

    /// <summary>
    /// Density of items buried on the floor map.
    /// </summary>
    public byte BuriedItemDensity { get; }

    /// <summary>
    /// Density of water tiles on the floor.
    /// </summary>
    public byte WaterDensity { get; }

    /// <summary>
    /// Represents the amount of tiles of vision in hallways, or full vision if 0.
    /// </summary>
    /// <remarks>
    /// Dungeons normally use 0, 1, or 2, but higher values will work.
    /// </remarks>
    public byte DarknessLevel { get; }

    /// <summary>
    /// Represents the max coin count spawned in piles.
    /// </summary>
    /// <remarks>
    /// The game stores this value / 5. As such, this value 
    /// is to be multiplied by 5 when read and divided by 5 when written 
    /// to be accurately represented.
    /// </remarks>
    public int MaxCoinAmount { get; }

    /// <summary>
    /// Controls where in a shop items will be placed.
    /// </summary>
    public byte KecleonShopItemPositions { get; }

    /// <summary>
    /// Chance that a spawned monster house will have no items.
    /// </summary>
    public byte EmptyMonsterHouseChance { get; }

    /// <summary>
    /// Type of hidden stairs that will be spawned.
    /// </summary>
    public HiddenStairType HiddenStairType { get; }

    /// <summary>
    /// Chance that a hidden stair will spawn on the floor.
    /// </summary>
    public byte HiddenStairsSpawnChance { get; }

    /// <summary>
    /// Amount of IQ that enemies will have on the floor.
    /// </summary>
    public ushort EnemyIq { get; }

    /// <summary>
    /// Amount the IQ is increased by the IQ booster when entering a floor.
    /// </summary>
    /// <remarks>
    /// Values less than or equal to 0 cause IQ to not be affected.
    /// </remarks>
    public short IqBoosterBoost { get; }

    /// <summary>
    /// Hash of the binary data this instance contains. Used for comparison.
    /// </summary>
    private readonly string md5;

    private MappaFloorLayout(
        FloorStructure structure,
        sbyte roomDensity,
        byte tilesetId,
        byte musicId,
        FloorWeather weather,
        byte floorConnectivity,
        sbyte initialEnemyDensity,
        byte kecleonShopChance,
        byte monsterHouseChance,
        byte unusedChance,
        byte stickyItemChance,
        bool deadEnds,
        byte secondaryTerrain,
        MappaFloorTerrainSettings terrainSettings,
        bool unkE,
        byte itemDensity,
        byte trapDensity,
        byte floorNumber,
        byte fixedFloorId,
        byte extraHallwayDensity,
        byte buriedItemDensity,
        byte waterDensity,
        byte darknessLevel,
        int maxCoinAmount,
        byte kecleonShopItemPositions,
        byte emptyMonsterHouseChance,
        HiddenStairType hiddenStairType,
        byte hiddenStairsSpawnChance,
        ushort enemyIq,
        short iqBoosterBoost,
        string md5Hash
    )
    {
        this.Structure = structure;
        this.RoomDensity = roomDensity;
        this.TilesetId = tilesetId;
        this.MusicId = musicId;
        this.Weather = weather;
        this.FloorConnectivity = floorConnectivity;
        this.InitialEnemyDensity = initialEnemyDensity;
        this.KecleonShopChance = kecleonShopChance;
        this.MonsterHouseChance = monsterHouseChance;
        this.UnusedChance = unusedChance;
        this.StickyItemChance = stickyItemChance;
        this.DeadEnds = deadEnds;
        this.SecondaryTerrain = secondaryTerrain;
        this.TerrainSettings = terrainSettings;
        this.UnkE = unkE;
        this.ItemDensity = itemDensity;
        this.TrapDensity = trapDensity;
        this.FloorNumber = floorNumber;
        this.FixedFloorId = fixedFloorId;
        this.ExtraHallwayDensity = extraHallwayDensity;
        this.BuriedItemDensity = buriedItemDensity;
        this.WaterDensity = waterDensity;
        this.DarknessLevel = darknessLevel;
        this.MaxCoinAmount = maxCoinAmount;
        this.KecleonShopItemPositions = kecleonShopItemPositions;
        this.EmptyMonsterHouseChance = emptyMonsterHouseChance;
        this.HiddenStairType = hiddenStairType;
        this.HiddenStairsSpawnChance = hiddenStairsSpawnChance;
        this.EnemyIq = enemyIq;
        this.IqBoosterBoost = iqBoosterBoost;
        this.md5 = md5Hash;
    }

    /// <summary>
    /// Converts the structure back into mappa binary.
    /// </summary>
    /// <returns></returns>
    public byte[] ToMappa()
    {
        byte[] data = new byte[32];
        using (BinaryWriter writer = new(new MemoryStream(data)))
        {
            writer.Write((byte)this.Structure);
            writer.Write(this.RoomDensity);
            writer.Write(this.TilesetId);
            writer.Write(this.MusicId);
            writer.Write((byte)this.Weather);
            writer.Write(this.FloorConnectivity);
            writer.Write(this.InitialEnemyDensity);
            writer.Write(this.KecleonShopChance);
            writer.Write(this.MonsterHouseChance);
            writer.Write(this.UnusedChance);
            writer.Write(this.StickyItemChance);
            writer.Write(this.DeadEnds);
            writer.Write(this.SecondaryTerrain);
            writer.Write(this.TerrainSettings.BitFlag);
            writer.Write(this.UnkE);
            writer.Write(this.ItemDensity);
            writer.Write(this.TrapDensity);
            writer.Write(this.FloorNumber);
            writer.Write(this.FixedFloorId);
            writer.Write(this.ExtraHallwayDensity);
            writer.Write(this.BuriedItemDensity);
            writer.Write(this.WaterDensity);
            writer.Write(this.DarknessLevel);
            writer.Write(this.MaxCoinAmount / 5);
            writer.Write(this.KecleonShopItemPositions);
            writer.Write(this.EmptyMonsterHouseChance);
            writer.Write((byte)this.HiddenStairType);
            writer.Write(this.HiddenStairsSpawnChance);
            writer.Write(this.EnemyIq);
            writer.Write(this.IqBoosterBoost);
        }

        return data;
    }

    /// <summary>
    /// Loads floor layout from mappa binary.
    /// </summary>
    /// <param name="mappaFloorData">32-length byte array containing the mappa floor data.</param>
    /// <returns></returns>
    public static MappaFloorLayout FromMappa(byte[] mappaFloorData)
    {
        if (mappaFloorData.Length != 32)
        {
            throw new ArgumentException(
                "The mappa floor binary data must be exactly 32 bytes in length.",
                nameof(mappaFloorData)
            );
        }

        using BinaryReader br = new(new MemoryStream(mappaFloorData));

        return new MappaFloorLayout(
            structure: (FloorStructure)br.ReadByte(),
            roomDensity: br.ReadSByte(),
            tilesetId: br.ReadByte(),
            musicId: br.ReadByte(),
            weather: (FloorWeather)br.ReadByte(),
            floorConnectivity: br.ReadByte(),
            initialEnemyDensity: br.ReadSByte(),
            kecleonShopChance: br.ReadByte(),
            monsterHouseChance: br.ReadByte(),
            unusedChance: br.ReadByte(),
            stickyItemChance: br.ReadByte(),
            deadEnds: br.ReadBoolean(),
            secondaryTerrain: br.ReadByte(),
            terrainSettings: new MappaFloorTerrainSettings(br.ReadByte()),
            unkE: br.ReadBoolean(),
            itemDensity: br.ReadByte(),
            trapDensity: br.ReadByte(),
            floorNumber: br.ReadByte(),
            fixedFloorId: br.ReadByte(),
            extraHallwayDensity: br.ReadByte(),
            buriedItemDensity: br.ReadByte(),
            waterDensity: br.ReadByte(),
            darknessLevel: br.ReadByte(),
            maxCoinAmount: br.ReadByte() * 5,
            kecleonShopItemPositions: br.ReadByte(),
            emptyMonsterHouseChance: br.ReadByte(),
            hiddenStairType: (HiddenStairType)br.ReadByte(),
            hiddenStairsSpawnChance: br.ReadByte(),
            enemyIq: br.ReadUInt16(),
            iqBoosterBoost: br.ReadInt16(),
            md5Hash: Convert.ToBase64String(MD5.HashData(mappaFloorData))
        );
    }

    /// <summary>
    /// Determines if two instances of <see cref="MappaFloorLayout"/> are equal.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
    public override bool Equals([NotNullWhen(true)] object obj)
    {
        if (obj is MappaFloorLayout other)
        {
            return ((IEquatable<MappaFloorLayout>)this).Equals(other);
        }

        return false;
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
    {
        return this.md5.GetHashCode();
    }

    /// <summary>
    /// Determines if two instances of <see cref="MappaFloorLayout"/> are equal.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>true if both objects are equal; otherwise, false.</returns>
    public static bool operator ==(MappaFloorLayout left, MappaFloorLayout right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines if two instances of <see cref="MappaFloorLayout"/> are not equal.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>true if both objects are not equal; otherwise, false.</returns>
    public static bool operator !=(MappaFloorLayout left, MappaFloorLayout right)
    {
        return !(left == right);
    }

    bool IEquatable<MappaFloorLayout>.Equals(MappaFloorLayout other)
    {
        return this.md5 == other.md5;
    }
}
