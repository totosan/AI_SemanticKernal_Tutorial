# AI Semantic Kernel Tutorial

This repository demonstrates the use of Microsoft Semantic Kernel for various AI-powered tasks.

## Projects

- **Semantic Kernel Sample**: Demonstrates text summarization, translation, mathematical operations, and anomaly detection.
- **Advanced Sample**: Includes file and folder operations, and integration with Azure OpenAI and Ollama models.
- **Simple API Call**: Shows how to make API calls to Azure OpenAI services.
- **Local SK**: Uses Semantic Kernel with local models like Ollama.

## Plugins

- **SamplePlugin**: Simplifies abstracts, translates text, extracts mathematical operations, counts words, and detects anomalies.
- **NativePlugIns**: Provides date/time operations, string manipulations, and mathematical operations.
- **AdvancedSample Plugins**: Handles file and folder operations.

## Getting Started

1. Clone the repository.
2. Set up environment variables in `launchSettings.json`.
3. Build and run the projects using `.vscode/tasks.json`.

## Dependencies

- Microsoft.SemanticKernel
- Microsoft.SemanticKernel.Connectors.AI.OpenAI
- Microsoft.SemanticKernel.Connectors.Ollama
- Microsoft.SemanticKernel.Planners.Handlebars
- Microsoft.SemanticKernel.Planners.OpenAI
- Tiktoken
- Azure.AI.OpenAI
- DotNetEnv

## License

Licensed under the MIT License.