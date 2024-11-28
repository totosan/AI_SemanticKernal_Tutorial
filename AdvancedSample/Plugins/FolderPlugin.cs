using System;
using System.ComponentModel;
using System.IO;
using Microsoft.SemanticKernel;

public class FolderPlugin
{
    // ...existing code...

    [KernelFunction]
    [Description("Creates a folder at the specified path.")]
    public void CreateFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    [KernelFunction]
    [Description("Deletes the folder at the specified path.")]
    public void DeleteFolder(string path)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }

    [KernelFunction]
    [Description("Lists all folders at the specified path.")]
    public string[] ListFolders(string path)
    {
        if (Directory.Exists(path))
        {
            return Directory.GetDirectories(path);
        }
        return Array.Empty<string>();
    }

    // ...existing code...
}
