namespace Gale.Files.Common.DungeonFloorGenerator;

public sealed class RandomGenProperties(
    int genType,
    int mul,
    int count,
    uint seedOldT0,
    uint seedT0,
    uint addT1,
    int useSeedT1,
    uint[] seedsT1
)
{
    public int GenType { get; } = genType;
    public int Mul { get; } = mul;
    public int Count { get; } = count;
    public uint SeedOldT0 { get; } = seedOldT0;
    public uint SeedT0 { get; } = seedT0;
    public uint AddT1 { get; } = addT1;
    public int UseSeedT1 { get; } = useSeedT1;
    public uint[] SeedsT1 { get; } = seedsT1;

    public static RandomGenProperties Default(Random random = null)
    {
        random ??= new Random();

        uint[] seeds = [
            (uint)random.NextInt64(1 << 32),
            (uint)random.NextInt64(1 << 32),
            (uint)random.NextInt64(1 << 32),
            (uint)random.NextInt64(1 << 32),
            (uint)random.NextInt64(1 << 32)
        ];

        return new RandomGenProperties(
            0,
            0x5D588B65,
            1,
            (uint)random.NextInt64(1 << 32),
            (uint)random.NextInt64(1 << 32),
            0x269EC3,
            4,
            seeds
        );
    }
}
