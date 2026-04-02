
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Model;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CoAntiCor.Core.Services
{
    public static class Helper
    {
        public static (double Lat, double Lng) ResolveCityCoordinates(string city) => city.ToLower() switch
        {
            "kisangani" => (0.5153, 25.1900),
            "lubumbashi" => (-11.6870, 27.5026),
            "goma" => (-1.6800, 29.2200),
            _ => (-4.0383, 21.7587)
        };

        public static double DistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        // --------------------------------------------------------------------
        // HELPER METHODS
        // --------------------------------------------------------------------

        public static decimal? ParseMaxPrice(string q)
        {
            var idx = q.IndexOf("under ");
            if (idx < 0) return null;

            var part = q[(idx + 6)..].Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            if (part is null) return null;

            part = part.Replace("k", "000");

            return decimal.TryParse(part, out var v) ? v : null;
        }

        public static string? ParseCrop(string q)
        {
            if (q.Contains("cocoa")) return "cocoa";
            if (q.Contains("coffee")) return "coffee";
            if (q.Contains("maize")) return "maize";
            return null;
        }

        public static string? ParseCity(string q)
        {
            if (q.Contains("kisan")) return "Kisangani";
            if (q.Contains("lubum")) return "Lubumbashi";
            if (q.Contains("goma")) return "Goma";
            return null;
        }

        public static async Task<(double Lat, double Lng)> ResolveCityCoordinatesAsync(string city)
        {
            // Replace with DB lookup if needed
            return ResolveCityCoordinates(city);
        }


        //public static (double Lat, double Lng) ResolveCityCoordinates(string city) =>
        //    city.ToLower() switch
        //    {
        //        "kisangani" => (0.5153, 25.1900),
        //        "lubumbashi" => (-11.6870, 27.5026),
        //        "goma" => (-1.6800, 29.2200),
        //        _ => (-4.0383, 21.7587)
        //    };

        //public static double DistanceKm(double lat1, double lon1, double lat2, double lon2)
        //{
        //    const double R = 6371;
        //    double dLat = (lat2 - lat1) * Math.PI / 180;
        //    double dLon = (lon2 - lon1) * Math.PI / 180;
        //    double a =
        //        Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        //        Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
        //        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        //    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        //    return R * c;
        //}

        public static string BuildPrompt(string query) => $@"
            You are a real estate assistant for the DRC.
            User query: ""{query}""

            Return a compact JSON object with:
            - city: string or null
            - crop: string or null
            - maxPriceUsd: number or null
        
            Example:
            {{ ""city"": ""Kisangani"", ""crop"": ""cocoa"", ""maxPriceUsd"": 20000 }}";

                                                                                                      
        public static void PageHeader(IContainer container, ContractLifecycleDto lifecycle)
        {
            container.Column(col =>
            {
                col.Item().Text($"Case File for Offer {lifecycle.OfferId}").FontSize(20).Bold();
                col.Item().Text($"Property: {lifecycle.PropertyAddress}");
                col.Item().Text($"Buyer: {lifecycle.BuyerName}");
                col.Item().Text($"Seller: {lifecycle.SellerName}");
            });
        }

        public static void PageLifecycle(IContainer container, ContractLifecycleDto lifecycle)                                                                         
        {
            container.Column(col =>
            {
                col.Item().Text("Lifecycle Timeline").FontSize(16).Bold().Underline();

                //foreach (var p in lifecycle.Payments)
                //{
                //    col.Item().Text($"Payment: {p.Type} - {p.Amount} {p.Currency} on {p.Timestamp:yyyy-MM-dd}");
                //}

                //foreach (var c in lifecycle.CadastreEvents)
                //{
                //    col.Item().Text($"Cadastre: {(c.IsValid ? "Valid" : "Invalid")} - {c.Timestamp:yyyy-MM-dd}");
                //}

                //foreach (var s in lifecycle.LandSplits)
                //{
                //    col.Item().Text($"Land Split: {s.Status} - {s.Timestamp:yyyy-MM-dd}");
                //}
            });
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

