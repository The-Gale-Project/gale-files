using Gale.Files.Graphics.DMA.Protocol;

namespace Gale.Files.Common.DungeonFloorGenerator;

public sealed class DungeonTile(
    DmaType terrain,
    int roomIndex,
    TileType tileType = TileType.Generic,
    RoomType roomType = RoomType.Normal
)
{
    public DmaType Terrain { get; } = terrain;
    public int RoomIndex { get; } = roomIndex;
    public TileType TileType { get; } = tileType;
    public RoomType RoomType { get; } = roomType;

    public override string ToString() => this.TileType switch
    {
        TileType.PlayerSpawn => "!",
        TileType.Stairs => ">",
        TileType.Enemy => "Ö",
        TileType.Trap => "+",
        TileType.BuriedItem => "i",
        TileType.Item => "I",
        _ => this.Terrain switch
        {
            DmaType.Wall => "X",
            DmaType.Water => "~",
            _ => this.RoomType switch
            {
                RoomType.KecleonShop => "K",
                RoomType.MonsterHouse => "M",
                _ => this.RoomIndex == 255 ? " " : this.RoomIndex.ToString(),
            },
        },
    };
}
