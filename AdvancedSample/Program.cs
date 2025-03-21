﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text.Json;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Diagnostics;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using System.Collections.Concurrent;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.AzureSdk;


namespace AdvancedSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Semantic Kernel
            var kernel = GetKernel();

            kernel.Plugins.AddFromObject(new FolderPlugin());
            kernel.Plugins.AddFromObject(new FilePlugin());

            Console.WriteLine("Welcome to the Semantic Kernel SinmpleCopilot!");
            Console.Write("What do you want me to do? ");
            var ask = Console.ReadLine();
            var chatSvc = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chat = new ChatHistory();
            chat.AddUserMessage(ask);
            var response = chatSvc.GetChatMessageContentAsync(chat, executionSettings: new (){FunctionChoiceBehavior= FunctionChoiceBehavior.Auto()}, kernel: kernel).Result;

            Debug.WriteLine(response);
        }


        private static Kernel GetKernel()
        {
            //return GetOpenAIKernel();
            return GetAzureKernel();
        }


        private static Kernel GetOpenAIKernel(string? useChatOrTextCompletionModel = "chat")
        {
            Kernel kernel;

            if (useChatOrTextCompletionModel == null || useChatOrTextCompletionModel == "chat")
            {
                kernel = Kernel.CreateBuilder()
                 .AddOpenAIChatCompletion(
                Environment.GetEnvironmentVariable("OPENAI_CHATCOMPLETION_DEPLOYMENT")!, // The name of your deployment (e.g., "gpt-3.5-turbo")
                Environment.GetEnvironmentVariable("OPENAI_API_KEY")!,
                Environment.GetEnvironmentVariable("OPENAI_ORGID")!)
            .Build();
            }
            else
                throw new Exception("Text Completion Models are deprected.");

            return kernel;
        }

        private static Kernel GetAzureKernel(string? useChatOrTextCompletionModel = "chat")
        {
            Kernel kernel;

            if (useChatOrTextCompletionModel == null || useChatOrTextCompletionModel == "chat")
            {
                kernel = Kernel.CreateBuilder()
                .AddAzureOpenAIChatCompletion(
                    Environment.GetEnvironmentVariable("AZURE_OPENAI_CHATCOMPLETION_DEPLOYMENT")!,  // The name of your deployment (e.g., "text-davinci-003")
                    Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")!,    // The endpoint of your Azure OpenAI service
                    Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")!      // The API key of your Azure OpenAI service
                )
                .Build();
            }
            else
            {
                kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
              Environment.GetEnvironmentVariable("AZURE_OPENAI_TEXTCOMPLETION_DEPLOYMENT")!,  // The name of your deployment (e.g., "text-davinci-003")
              Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")!,    // The endpoint of your Azure OpenAI service
              Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")!      // The API key of your Azure OpenAI service
          )
          .Build();
            }
            return kernel;
        }
    }
}