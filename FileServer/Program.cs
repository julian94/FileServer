using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/Files",
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Files")),
});

app.MapGet("/files.json", () =>
{
    return new Folder { Name = "root" };
});

app.Run();


public class Folder
{
    public string Name { get; set; }
    public List<Folder> SubFolders { get; set; }
    public List<File> Files { get; set; }

}

public class File
{
    public string Name { get; set; }
}
