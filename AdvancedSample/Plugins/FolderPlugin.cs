using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

namespace SKTrainingSolution.AdvancedSample
{
    public class FolderPlugin
    {
        [KernelFunction, Description("Creates a new folder if it does not already exist.")]
        public async Task CreateFolderAsync(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                await Task.CompletedTask;
            }
            else
            {
                throw new IOException("Directory already exists.");
            }
        }

        [KernelFunction, Description("Deletes the specified folder if it exists.")]
        public async Task DeleteFolderAsync(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                await Task.CompletedTask;
            }
            else
            {
                throw new IOException("Directory does not exist.");
            }
        }

        [KernelFunction, Description("Lists all subfolders within the specified folder.")]
        public async Task<string[]> ListFoldersAsync(string path)
        {
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path);
                return await Task.FromResult(directories);
            }
            else
            {
                throw new IOException("Directory does not exist.");
            }
        }

        [KernelFunction, Description("Lists all files within the specified folder.")]
        public async Task<string[]> ListFilesAsync(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                return await Task.FromResult(files);
            }
            else
            {
                throw new IOException("Directory does not exist.");
            }
        }
    }
}