using CoAntiCor.Components.Account.Pages.Manage;
using Humanizer;
using Microsoft.Extensions.Hosting;

namespace CoAntiCor.Util
{
    /// <summary>
    /// 2. Data retention and redaction rules
    /// You’re dealing with sensitive corruption reports, so you want:
    ///- Strong legal defensibility
    ///- Protection of whistleblowers
    ///- Minimal but sufficient traceability
    ///I’ll outline a practical, regulator‑friendly policy you can encode into the system.

    /// </summary>
    public static class Redaction
    {
        // Redaction on export
        // - Regulator exports(CSV/PDF) should:
        // - Show complaint numbers, statuses, actions, usernames of staff.
        // - For citizens:
        // - Show at most partial identifiers(e.g.jo*** @example.com, +243*******12) unless regulator has explicit legal basis to see full.
        // - Implement a small helper:

        public static string RedactEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return string.Empty;
            var at = email.IndexOf('@');
            if (at <= 1) return "***";
            return email[0] + "***" + email.Substring(at);
        }

        public static string RedactPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return string.Empty;
            if (phone.Length <= 4) return "****";
            return new string('*', phone.Length - 2) + phone[^2..];
        }
    }
}
