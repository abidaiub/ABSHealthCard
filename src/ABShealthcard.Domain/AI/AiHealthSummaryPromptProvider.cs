using System.Text;
using ABShealthcard.Patients;
using Volo.Abp.Domain.Services;

namespace ABShealthcard.AI;

public class AiHealthSummaryPromptProvider : DomainService
{
    public string BuildEnglishPrompt(PatientHealthSummary summary)
    {
        var sb = new StringBuilder();

        sb.AppendLine("You are a medical assistant.");
        sb.AppendLine("Your task is to explain the patient's health summary.");
        sb.AppendLine("Do NOT diagnose. Do NOT suggest treatment.");
        sb.AppendLine("Only explain findings already provided.");
        sb.AppendLine();
        sb.AppendLine("Patient Health Data (JSON):");
        sb.AppendLine(summary.KeyFindingsJson);
        sb.AppendLine(summary.RiskFlagsJson);
        sb.AppendLine();
        sb.AppendLine("Write a clear, calm, patient-friendly explanation.");

        return sb.ToString();
    }

    public string BuildBanglaPrompt(PatientHealthSummary summary)
    {
        var sb = new StringBuilder();

        sb.AppendLine("আপনি একজন মেডিকেল সহকারী।");
        sb.AppendLine("আপনার কাজ হলো রোগীর স্বাস্থ্য সারাংশ সহজ ভাষায় ব্যাখ্যা করা।");
        sb.AppendLine("কোনো রোগ নির্ণয় করবেন না।");
        sb.AppendLine("চিকিৎসা বা ওষুধ পরামর্শ দেবেন না।");
        sb.AppendLine("শুধুমাত্র নিচে দেওয়া তথ্য ব্যাখ্যা করুন।");
        sb.AppendLine();
        sb.AppendLine("রোগীর স্বাস্থ্য তথ্য (JSON):");
        sb.AppendLine(summary.KeyFindingsJson);
        sb.AppendLine(summary.RiskFlagsJson);
        sb.AppendLine();
        sb.AppendLine("সহজ, শান্ত ও রোগী-বান্ধব ভাষায় ব্যাখ্যা লিখুন।");

        return sb.ToString();
    }

    // Future:
    // - Prompt versioning
    // - Doctor vs Patient prompt variants
    // - Emergency vs Routine tone
    // - Token optimization strategies
    // - Prompt A/B testing
}
