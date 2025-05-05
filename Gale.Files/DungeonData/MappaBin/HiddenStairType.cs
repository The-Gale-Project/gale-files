namespace Gale.Files.DungeonData.MappaBin;

/// <summary>
/// Represents the type of hidden stairs to spawn on a floor.
/// </summary>
public enum HiddenStairType : byte
{
    /// <summary>
    /// Spawn stairs to the secret bazaar.
    /// </summary>
    SecretBazaar,

    /// <summary>
    /// Spawn stairs to a secret room.
    /// </summary>
    SecretRoom,

    /// <summary>
    /// 50% chance of either the secret bazaar or a secret room.
    /// </summary>
    Random = 255
}
