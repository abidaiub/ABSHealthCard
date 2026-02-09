using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ABShealthcard.AI;

public class OpenAiTextCompletionClient : IAiTextCompletionClient
{
    private readonly HttpClient _http;
    private readonly AiProviderOptions _options;

    public OpenAiTextCompletionClient(
        HttpClient http,
        IOptions<AiProviderOptions> options)
    {
        _http = http;
        _options = options.Value;
        _http.Timeout = System.TimeSpan.FromSeconds(_options.TimeoutSeconds);
    }

    public async Task<string> CompleteAsync(string prompt, int maxTokens)
    {
        var body = new
        {
            model = _options.Model,
            messages = new[]
            {
                new { role = "user", content = prompt }
            },
            max_tokens = maxTokens
        };

        using var req = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.openai.com/v1/chat/completions");

        req.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", _options.ApiKey);

        req.Content = new StringContent(
            JsonSerializer.Serialize(body),
            Encoding.UTF8,
            "application/json");

        using var res = await _http.SendAsync(req);
        res.EnsureSuccessStatusCode();

        var json = await res.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);

        return doc
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? string.Empty;
    }
}
