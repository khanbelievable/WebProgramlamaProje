namespace WebProgramlamaProje.Services
{
    public interface IAISuggestionService
    {
        string GetExerciseSuggestion(string goal, string level);
    }

    public class AISuggestionService : IAISuggestionService
    {
        public string GetExerciseSuggestion(string goal, string level)
        {
            // Rule-based "AI" simulation
            if (goal.ToLower().Contains("kilo") || goal.ToLower().Contains("weight"))
            {
                return level.ToLower() switch
                {
                    "baslangic" or "beginner" => "Haftada 3 gün 30 dakika tempolu yürüyüş ve temel vücut ağırlığı egzersizleri (squat, push-up).",
                    "orta" or "intermediate" => "Haftada 4 gün 45 dakika HIIT antrenmanı ve bölgesel ağırlık çalışması.",
                    _ => "Haftada 5 gün cardio ve ağır bileşik egzersizler (deadlift, squat)."
                };
            }
            else if (goal.ToLower().Contains("kas") || goal.ToLower().Contains("muscle"))
            {
                return level.ToLower() switch
                {
                    "baslangic" or "beginner" => "Tüm vücut (Full body) antrenmanı, haftada 3 gün, düşük ağırlık yüksek tekrar.",
                    "orta" or "intermediate" => "Bölgesel (Split) antrenman, haftada 4 gün, orta ağırlık.",
                    _ => "İleri seviye split antrenman, haftada 5-6 gün, yüksek yoğunluklu setler."
                };
            }
            
            return "Haftalık düzenli yürüyüş ve esneme hareketleri genel sağlık için önerilir.";
        }
    }
}
