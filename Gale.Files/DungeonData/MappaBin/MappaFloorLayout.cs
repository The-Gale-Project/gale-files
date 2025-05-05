namespace Gale.Files.DungeonData.MappaBin;

/// <summary>
/// Structure used to store mappa floor layout data.
/// </summary>
/// <param name="structure">The structure of the floor.</param>
/// <param name="roomDensity">The density of the rooms on the floor.</param>
/// <param name="tilesetId">The tileset that will be used for this floor.</param>
/// <param name="musicId">The music that will play on the floor.</param>
/// <param name="weather">Type of weather that will appear.</param>
/// <param name="floorConnectivity"></param>
/// <param name="initialEnemyDensity">Amount of enemies that spawn on the floor when first loaded.</param>
/// <param name="kecleonShopChance">The chance this floor will have a shop.</param>
/// <param name="monsterHouseChance">The chance this floor will have a monster house.</param>
/// <param name="unusedChance">Unused unless using the relevant patch.</param>
/// <param name="stickyItemChance">Chance that a spawned item will be sticky.</param>
/// <param name="deadEnds">True if dead ends should be generated, otherwise false.</param>
/// <param name="secondaryTerrain">If greater than 0, rooms on the floor will spawn with secondary terrain (water, lava, void).</param>
/// <param name="terrainSettings">Bitflag which stores extra terrain settings.</param>
/// <param name="unkE">UNK: This seems to be unused.</param>
/// <param name="itemDensity">Determines the amount of items spawned on a floor.</param>
/// <param name="trapDensity">Determines the amount of traps spawned on a floor.</param>
/// <param name="floorNumber">The number of the floor.</param>
/// <param name="fixedFloorId">Represents the ID of a fixed floor or floor part.</param>
/// <param name="extraHallwayDensity">Adds extra (mostly confusing) hallways to the floor.</param>
/// <param name="buriedItemDensity">Determines the amount of buried items spawned on a floor.</param>
/// <param name="waterDensity">Determines the amount of water spawned on the floor.</param>
/// <param name="darknessLevel">Determines how far that can be seen in hallways.</param>
/// <param name="maxCoinAmount">Max amount of coins to be spawned in each 'pile'.</param>
/// <param name="kecleonShopItemPositions">Determines the spawn position of shop items.</param>
/// <param name="emptyMonsterHouseChance">Chance that a monster house will spawn with no items.</param>
/// <param name="hiddenStairType">Determines the type of hidden stair spawned.</param>
/// <param name="hiddenStairsSpawnChance">Chance that a hidden stair will spawn on the floor.</param>
/// <param name="enemyIq">Amount of IQ enemies have on this floor.</param>
/// <param name="iqBoosterBoost">Amount of IQ gained from the IQ Booster on this floor, or none if less than or equal to 0.</param>
public readonly struct MappaFloorLayout(
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
    short iqBoosterBoost
)
{
    /// <summary>
    /// The structure of the floor.
    /// </summary>
    public FloorStructure Structure { get; } = structure;

    /// <summary>
    /// The density of the rooms on the floor.
    /// The game randomly adds a number between 0 
    /// and 2 to obtain the final value.
    /// </summary>
    public sbyte RoomDensity { get; } = roomDensity;

    /// <summary>
    /// The ID of the tileset to be used for this floor.
    /// </summary>
    public byte TilesetId { get; } = tilesetId;

    /// <summary>
    /// The ID of the music to play, based on a seperate table 
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
    public byte MusicId { get; } = musicId;

    /// <summary>
    /// The weather that will occur on this floor.
    /// </summary>
    public FloorWeather Weather { get; } = weather;

    /// <summary>
    /// Amount of connections between cells that will be generated
    /// when the map is first created. More connections are added
    /// later to ensure that all the rooms can be accessed.
    /// </summary>
    /// <remarks>
    /// Minimum 1, if 0 then the generation fails and falls back
    /// to <see cref="FloorStructure.SingleRoomMonsterHouse"/>.
    /// </remarks>
    public byte FloorConnectivity { get; } = floorConnectivity;

    /// <summary>
    /// Initial enemy density.
    /// </summary>
    public sbyte InitialEnemyDensity { get; } = initialEnemyDensity;

    /// <summary>
    /// Chance that a shop will spawn on this floor.
    /// </summary>
    public byte KecleonShopChance { get; } = kecleonShopChance;

    /// <summary>
    /// Chance that a monster house will spawn on this floor.
    /// </summary>
    public byte MonsterHouseChance { get; } = monsterHouseChance;

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
    public byte UnusedChance { get; } = unusedChance;

    /// <summary>
    /// Chance that an item will spawn sticky.
    /// </summary>
    public byte StickyItemChance { get; } = stickyItemChance;

    /// <summary>
    /// True if dead ends are allowed on the floor, otherwise false.
    /// </summary>
    public bool DeadEnds { get; } = deadEnds;

    /// <summary>
    /// If greater than 0, rooms on the floor will spawn with secondary
    /// terrain (water, lava, void).
    /// </summary>
    public byte SecondaryTerrain { get; } = secondaryTerrain;

    /// <summary>
    /// Set of bitflags used to control extra terrain settings.
    /// </summary>
    public MappaFloorTerrainSettings TerrainSettings { get; } = terrainSettings;

    /// <summary>
    /// UNK: This seems to be unused.
    /// </summary>
    public bool UnkE { get; } = unkE;

    /// <summary>
    /// The density of items spawned on the floor map.
    /// </summary>
    public byte ItemDensity { get; } = itemDensity;

    /// <summary>
    /// Density of traps on the floor, calculated randomly between
    /// <see cref="TrapDensity"/> / 2 and <see cref="TrapDensity"/>
    /// </summary>
    public byte TrapDensity { get; } = trapDensity;

    /// <summary>
    /// The number of this floor.
    /// </summary>
    public byte FloorNumber { get; } = floorNumber;

    /// <summary>
    /// ID of the fixed floor or floor fragment of this floor.
    /// This includes key chambers, boss battle rooms, final rooms, etc.
    /// </summary>
    public byte FixedFloorId { get; } = fixedFloorId;

    /// <summary>
    /// Used to generate additional hallways in the map (those "donuts" 
    /// that lead to nowhere, multiple entrances to the same room, 
    /// room exits connected to the same room, those dead ends that 
    /// come out of a room,  make a couple of twists and also lead to nowhere).
    /// </summary>
    public byte ExtraHallwayDensity { get; } = extraHallwayDensity;

    /// <summary>
    /// Density of items buried on the floor map.
    /// </summary>
    public byte BuriedItemDensity { get; } = buriedItemDensity;

    /// <summary>
    /// Density of water tiles on the floor.
    /// </summary>
    public byte WaterDensity { get; } = waterDensity;

    /// <summary>
    /// Represents the amount of tiles of vision in hallways, or full vision if 0.
    /// </summary>
    /// <remarks>
    /// Dungeons normally use 0, 1, or 2, but higher values will work.
    /// </remarks>
    public byte DarknessLevel { get; } = darknessLevel;

    /// <summary>
    /// Represents the max coin count spawned in piles.
    /// </summary>
    /// <remarks>
    /// The game stores this value / 5. As such, this value 
    /// is to be multiplied by 5 when read and divided by 5 when written 
    /// to be accurately represented.
    /// </remarks>
    public int MaxCoinAmount { get; } = maxCoinAmount;

    /// <summary>
    /// Controls where in a shop items will be placed.
    /// </summary>
    public byte KecleonShopItemPositions { get; } = kecleonShopItemPositions;

    /// <summary>
    /// Chance that a spawned monster house will have no items.
    /// </summary>
    public byte EmptyMonsterHouseChance { get; } = emptyMonsterHouseChance;

    /// <summary>
    /// Type of hidden stairs that will be spawned.
    /// </summary>
    public HiddenStairType HiddenStairType { get; } = hiddenStairType;

    /// <summary>
    /// Chance that a hidden stair will spawn on the floor.
    /// </summary>
    public byte HiddenStairsSpawnChance { get; } = hiddenStairsSpawnChance;

    /// <summary>
    /// Amount of IQ that enemies will have on the floor.
    /// </summary>
    public ushort EnemyIq { get; } = enemyIq;

    /// <summary>
    /// Amount the IQ is increased by the IQ booster when entering a floor.
    /// </summary>
    /// <remarks>
    /// Values less than or equal to 0 cause IQ to not be affected.
    /// </remarks>
    public short IqBoosterBoost { get; } = iqBoosterBoost;

    /// <summary>
    /// 
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
    /// <param name="reader">Mappa binary reader.</param>
    /// <param name="offset">Offset of the floor layout data within the mappa file.</param>
    /// <returns></returns>
    public static MappaFloorLayout FromMappa(MappaBinReader reader, int offset)
    {
        BinaryReader br = reader.Read;
        br.BaseStream.Seek(offset, SeekOrigin.Begin);

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
            iqBoosterBoost: br.ReadInt16()
        );
    }

    // TODO: implement Equals and associated operators, probably using a hash of the binary data.
}
