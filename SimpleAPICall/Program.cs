using Azure.AI.OpenAI;
using Azure;

DotNetEnv.Env.Load();

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
string deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_MODEL");

var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

var chatCompletionsOptions = new ChatCompletionsOptions
{
    DeploymentName = deploymentName,
    Messages = { new ChatRequestUserMessage("Hallo, wie geht es dir?") },
    MaxTokens = 800,
    Temperature = 0.7f,
};

var response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
Console.WriteLine(response.Value.Choices[0].Message.Content);