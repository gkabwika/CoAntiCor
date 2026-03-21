
using CoAntiCor.Events;
using System.Text.Json;

namespace CoAntiCor.Services
{
    public class Helper
    {
        //private static ICompanyEvent DeserializeEvent(CompanyCreationEvent record)
        //{
        //    return record.EventType switch
        //    {
        //        nameof(CompanyStarted) =>
        //            JsonSerializer.Deserialize<CompanyStarted>(record.DataJson)!,

        //        nameof(CompanyBasicInfoUpdated) =>
        //            JsonSerializer.Deserialize<CompanyBasicInfoUpdated>(record.DataJson)!,

        //        nameof(CompanyAddressUpdated) =>
        //            JsonSerializer.Deserialize<CompanyAddressUpdated>(record.DataJson)!,

        //        nameof(CompanyContactUpdated) =>
        //            JsonSerializer.Deserialize<CompanyContactUpdated>(record.DataJson)!,

        //        nameof(CompanyCompleted) =>
        //            JsonSerializer.Deserialize<CompanyCompleted>(record.DataJson)!,

        //        _ => throw new InvalidOperationException(
        //            $"Unknown event type '{record.EventType}'")
        //    };
        //}


    }
}
