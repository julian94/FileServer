using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Files"));
fileProvider.UsePollingFileWatcher = true;

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/Files",
    FileProvider = fileProvider,
});


app.MapGet("/files.json", () => GetFolder(""));

app.Run();

Folder GetFolder(string subpath)
{
    var folder = new Folder {
        Name = subpath.Split("/").Last(),
        Path = "./Files" + subpath + "/",
        SubFolders = new(),
        Files = new (),
    };

    var content = fileProvider.GetDirectoryContents(subpath);

    // Recursively add Subfolders

    // Add all files in current folder.

    foreach (var file in content)
    {
        if (file.IsDirectory)
        {
            folder.SubFolders.Add(GetFolder(subpath + "/" + file.Name));
        }
        else
        {
            folder.Files.Add(new File
            {
                Name = file.Name,
                Path = "./Files" + subpath + "/" + file.Name,
            });
        }
    }

    return folder;
}

public class Folder
{
    public string Name { get; init; }
    public string Path { get; init; }
    public List<Folder> SubFolders { get; init; }
    public List<File> Files { get; init; }

}

public class File
{
    public string Name { get; init; }
    public string Path { get; init; }
}
