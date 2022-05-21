export class FileItem {
    Name: string;
    Path: string;

    constructor(
            name: string,
            path: string){
        this.Name = name;
        this.Path = path;
    }
}

export class FolderItem {
    Name: string;
    Path: string;
    Files: FileItem[];
    Folders: FolderItem[];

    constructor(
            name: string,
            path: string,
            files: FileItem[],
            folders: FolderItem[]){
        this.Name = name;
        this.Path = path;
        this.Files = files;
        this.Folders = folders;
    }
}
