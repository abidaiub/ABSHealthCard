namespace ABShealthcard.AI;

public class AiProviderOptions
{
    public string Provider { get; set; } = "OpenAI"; // or AzureOpenAI
    public string ApiKey { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty; // for Azure
    public string Model { get; set; } = "gpt-4o-mini";
    public int TimeoutSeconds { get; set; } = 10;
}
