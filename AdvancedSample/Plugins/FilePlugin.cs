// create a class containing file operations annotated with the [KernelFunction] and description attribute for semantic kernel
using System;
using System.ComponentModel;
using System.IO;
using Microsoft.SemanticKernel;

namespace SKTrainingSolution.AdvancedSample
{
    public class FilePlugin
    {
        [KernelFunction, Description("Reads the content of a file.")]
        public string ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            throw new FileNotFoundException("File not found.", filePath);
        }

        [KernelFunction, Description("Writes content to a file.")]
        public void WriteFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        [KernelFunction, Description("Appends content to a file.")]
        public void AppendToFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        [KernelFunction, Description("Deletes a file.")]
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new FileNotFoundException("File not found.", filePath);
            }
        }
    }
}
