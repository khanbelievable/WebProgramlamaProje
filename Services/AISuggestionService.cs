using System.Text;
using System.Text.Json;

namespace WebProgramlamaProje.Services
{
    public interface IAISuggestionService
    {
        Task<string> GetExerciseSuggestionAsync(string goal, string level, string notes);
    }

    public class AISuggestionService : IAISuggestionService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AISuggestionService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetExerciseSuggestionAsync(string goal, string level, string notes)
        {
            string apiKey = (_configuration["AI:OpenRouterApiKey"] ?? "").Trim();

            if (string.IsNullOrEmpty(apiKey) || apiKey == "YOUR_API_KEY_HERE" || apiKey.Length < 10)
            {
                return "❌ OpenRouter API anahtarı yapılandırılmamış. Lütfen appsettings.json dosyasına geçerli bir OpenRouter API anahtarı ekleyin.";
            }

            var prompt = $@"Sen profesyonel bir fitness eğitmenisin. Aşağıdaki bilgilere göre detaylı ve kişiselleştirilmiş bir haftalık antrenman planı hazırla:

Hedef: {goal}
Seviye: {level}
{(!string.IsNullOrEmpty(notes) ? $"Özel Notlar: {notes}" : "")}

Lütfen şunları içeren detaylı bir plan oluştur:
- Haftalık antrenman programı (günlük egzersizler)
- Her egzersiz için set ve tekrar sayıları
- Beslenme önerileri
- Önemli ipuçları

Planı Türkçe ve profesyonel bir dille hazırla.";

            try
            {
                var requestBody = new
                {
                    model = "google/gemini-2.0-flash-exp:free",
                    messages = new[]
                    {
                        new { role = "system", content = "Sen profesyonel bir fitness eğitmeni ve beslenme danışmanısın." },
                        new { role = "user", content = prompt }
                    },
                    temperature = 0.7,
                    max_tokens = 1500
                };

                var jsonPayload = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "https://localhost:7198");
                _httpClient.DefaultRequestHeaders.Add("X-Title", "Fitness Center");

                var response = await _httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);
                var responseJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using var doc = JsonDocument.Parse(responseJson);
                    var aiResponse = doc.RootElement
                        .GetProperty("choices")[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();

                    return aiResponse ?? "OpenRouter boş yanıt döndürdü.";
                }
                else
                {
                    return $"❌ OpenRouter API Hatası ({response.StatusCode})\n\nDetay: {responseJson}\n\nLütfen API anahtarınızın geçerli olduğundan ve kredilerinizin yeterli olduğundan emin olun.";
                }
            }
            catch (Exception ex)
            {
                return $"❌ Bağlantı Hatası: {ex.Message}\n\nLütfen internet bağlantınızı kontrol edin.";
            }
        }
    }
}
