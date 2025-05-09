using System.Reflection;

internal static class EmbeddedResourceReader
{
    public static string ReadResource(string name)
    {
        // Determine path
        Assembly assembly = Assembly.GetExecutingAssembly();
        string resourcePath = name;
        resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));

        using Stream stream = assembly.GetManifestResourceStream(resourcePath);
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
}
