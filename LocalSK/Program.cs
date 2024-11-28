using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder();
builder.AddOllamaChatCompletion("llama3.2:latest", new Uri("http://localhost:11434"));

var kernel = builder.Build();
var chatService = kernel.GetRequiredService<IChatCompletionService>();

var history = new ChatHistory();
history.AddSystemMessage("You are a helpful assistant.");

while (true)
{
    Console.Write("You: ");
    var userMessage = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userMessage))
    {
        break;
    }

    history.AddUserMessage(userMessage);

    var response = await chatService.GetChatMessageContentAsync(history);

    Console.WriteLine($"Bot: {response.Content}");

    history.AddMessage(response.Role, response.Content ?? string.Empty);
}
