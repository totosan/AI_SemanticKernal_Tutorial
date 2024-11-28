using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

public class FilePlugin
{
    // ...existing code...

    [KernelFunction]
    [Description("Reads the content of a file.")]
    public async Task<string> ReadFileAsync([Description("this is the filepath")]string filePath )
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        using (var reader = new StreamReader(filePath))
        {
            return await reader.ReadToEndAsync();
        }
    }

    [KernelFunction]
    [Description("Writes content to a file.")]
    public async Task WriteFileAsync(string filePath, string content)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        using (var writer = new StreamWriter(filePath))
        {
            await writer.WriteAsync(content);
        }
    }

    [KernelFunction]
    [Description("Deletes a file.")]
    public void DeleteFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        File.Delete(filePath);
    }
}
