using System.Text;

namespace Gale.Files.Common.Exceptions;

/// <summary>
/// Raised when trying to apply an ASM patch that
/// depends on patch(es) that exist but are outdated.
/// </summary>
/// <param name="message"></param>
/// <param name="patchName"></param>
/// <param name="outdatedDependencies"></param>
public sealed class OutdatedPatchDependencyException(
    string message,
    string patchName,
    params string[] outdatedDependencies
) : Exception(BuildMessage(message, patchName, outdatedDependencies))
{
    private static string BuildMessage(string message, string patchName, string[] outdatedDependencies)
    {
        StringBuilder messageBuilder = new();
        messageBuilder.AppendLine(
            $"The patch {patchName} cannot be applied because the following patches it depends on are outdated:"
        );

        foreach (string dependency in outdatedDependencies)
        {
            messageBuilder.AppendLine($"\t{dependency}");
        }

        messageBuilder.AppendLine("Please reapply these patches first.");
        return messageBuilder.ToString();
    }
}
