using System.Threading.Tasks;

namespace ABShealthcard.AI;

public interface IAiTextCompletionClient
{
    Task<string> CompleteAsync(string prompt, int maxTokens);
}
