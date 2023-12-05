namespace FileManager;

public static class UniqueNameGenerator
{
    public static string GenerateUniqueFileName(string fileName, string directory)
    {
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));
        var counter = 0;
        var uniqueFileName = fileName[(fileName.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        var extension = Path.GetExtension(fileName);

        while (Path.Exists(Path.Combine(directory, uniqueFileName)))
        {
            uniqueFileName = $"{fileNameWithoutExtension}({counter}){extension}";
            counter++;
        }

        return uniqueFileName;
    }
}