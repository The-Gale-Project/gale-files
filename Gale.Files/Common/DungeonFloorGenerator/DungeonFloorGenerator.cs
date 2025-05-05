namespace Gale.Files.Common.DungeonFloorGenerator;

public sealed class DungeonFloorGenerator(
    bool unknownDungeonChancePatchApplied = false,
    bool fixDeadEndError = false,
    bool fixOuterRoomError = false,
    RandomGenProperties genProperties = null
)
{
    private const int SIZE_X = 32;
    private const int SIZE_Y = 56;

    public bool UnknownDungeonChancePatchApplied { get; } = unknownDungeonChancePatchApplied;
    public bool FixDeadEndError { get; } = fixDeadEndError;
    public bool FixOuterRoomError { get; } = fixOuterRoomError;
    public RandomGenProperties GenProperties { get; } = genProperties;

    // TODO: Figure out what this class is used for exactly.
    //public List<List<DungeonTile>> Generate()
}
