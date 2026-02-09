using System.Collections.Generic;
using Volo.Abp.Domain.Services;

namespace ABShealthcard.Labs;

public class LabResultExplanationProvider : DomainService
{
    private static readonly Dictionary<(string TestCode, string Status), string> _banglaMap
        = new()
        {
            { ("HBA1C", "High"), "রক্তে গ্লুকোজ নিয়ন্ত্রণে নেই। ডাক্তারের পরামর্শ প্রয়োজন।" },
            { ("HBA1C", "Normal"), "রক্তে গ্লুকোজ বর্তমানে স্বাভাবিক মাত্রায় আছে।" },

            { ("HB", "Low"), "রক্তস্বল্পতার লক্ষণ থাকতে পারে।" },
            { ("HB", "Normal"), "হিমোগ্লোবিন স্বাভাবিক মাত্রায় আছে।" },

            { ("TSH", "High"), "থাইরয়েড হরমোনের সমস্যা থাকতে পারে।" },
            { ("TSH", "Normal"), "থাইরয়েড হরমোন স্বাভাবিক আছে।" }
        };

    public string GetBanglaExplanation(string testCode, string resultStatus)
    {
        if (_banglaMap.TryGetValue((testCode, resultStatus), out var explanation))
        {
            return explanation;
        }

        return "এই রিপোর্ট সম্পর্কে বিস্তারিত জানতে ডাক্তারের সাথে যোগাযোগ করুন।";
    }

    // Future:
    // - Database-driven explanation rules
    // - Severity-based wording
    // - AI-enhanced natural language explanation
    // - Voice explanation (Bangla TTS)
}
