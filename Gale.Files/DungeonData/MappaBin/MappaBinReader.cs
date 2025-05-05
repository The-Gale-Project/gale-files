namespace Gale.Files.DungeonData.MappaBin;

/// <summary>
/// Handles reading the mappa binary file using <see cref="BinaryReader"/>.
/// </summary>
public sealed class MappaBinReader : IDisposable
{
    /// <summary>
    /// Binary data reader for the underlying binary mappa file.
    /// </summary>
    public BinaryReader Read { get; }

    /// <summary>
    /// Offset for the dungeon list.
    /// </summary>
    public uint DungeonListOffset { get; }

    /// <summary>
    /// Offset for the floor layout data.
    /// </summary>
    public uint FloorLayoutDataOffset { get; }

    /// <summary>
    /// Offset for the item spawn list.
    /// </summary>
    public uint ItemSpawnListOffset { get; }

    /// <summary>
    /// Offset for the monster spawn list.
    /// </summary>
    public uint MonsterSpawnListOffset { get; }

    /// <summary>
    /// Offset for the trap spawn list.
    /// </summary>
    public uint TrapSpawnListOffset { get; }

    /// <summary>
    /// Initializes the reader for the supplied Mappa binary file.
    /// After reading the header, the underlying <see cref="BinaryReader"/>
    /// is reset to Position 0.
    /// </summary>
    /// <param name="data">Mappa binary data, in bytes.</param>
    /// <param name="headerOffset">Offset of the header data.</param>
    public MappaBinReader(
        byte[] data,
        long headerOffset
    )
    {
        MemoryStream ms = new(data);
        this.Read = new BinaryReader(ms);

        this.Read.BaseStream.Seek(headerOffset, SeekOrigin.Begin);
        this.DungeonListOffset = this.Read.ReadUInt32();
        this.FloorLayoutDataOffset = this.Read.ReadUInt32();
        this.ItemSpawnListOffset = this.Read.ReadUInt32();
        this.MonsterSpawnListOffset = this.Read.ReadUInt32();
        this.TrapSpawnListOffset = this.Read.ReadUInt32();
        this.Read.BaseStream.Seek(0x00, SeekOrigin.Begin);
    }

    /// <summary>
    /// Releases all resources used by the underlying <see cref="BinaryReader"/>.
    /// </summary>
    public void Dispose()
    {
        this.Read?.Dispose();
    }
}
