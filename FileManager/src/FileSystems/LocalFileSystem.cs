namespace FileManager.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public void CopyFile(string pathFrom, string pathTo)
    {
        var newFileName = UniqueNameGenerator.GenerateUniqueFileName(pathFrom, pathTo);
        File.Copy(pathFrom, Path.Combine(pathTo, newFileName));
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void MoveFile(string pathFrom, string pathTo)
    {
        var newFileName = UniqueNameGenerator.GenerateUniqueFileName(pathFrom, pathTo);
        File.Move(pathFrom, Path.Combine(pathTo, newFileName));
    }

    public void RenameFile(string path, string newName)
    {
        if (path is null)
            throw new ArgumentNullException(nameof(path));
        var pathWithoutName = path[..path.LastIndexOf(Path.DirectorySeparatorChar)];
        File.Move(path, Path.Combine(pathWithoutName, newName));
    }
}