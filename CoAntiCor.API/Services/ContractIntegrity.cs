using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using System;

namespace CoAntiCor.API.Services
{
    /// <summary>
    ///  Log on contract finalization (after fully signed)
    /// Extend your sign endpoints:
    /// </summary>
    public class ContractIntegrity
    {
        async Task LogContractIntegrityAsync(Contract contract, CoAntiCorDbContext db, IContractPdfService pdf, string userId)
        {
            var pdfBytes = pdf.Generate(contract);

            var meta = $"{contract.Id}|{contract.ContractNumber}|{contract.Status}|{contract.BuyerSignedAtUtc:O}|{contract.SellerSignedAtUtc:O}";
            var metaBytes = System.Text.Encoding.UTF8.GetBytes(meta);

            var combined = new byte[pdfBytes.Length + metaBytes.Length];
            Buffer.BlockCopy(pdfBytes, 0, combined, 0, pdfBytes.Length);
            Buffer.BlockCopy(metaBytes, 0, combined, pdfBytes.Length, metaBytes.Length);

            var hash = IntegrityHasher.ComputeSha256Hex(combined);

            db.IntegrityLogs.Add(new IntegrityLog
            {
                Id = Guid.NewGuid(),
                ObjectType = "Contract",
                ObjectId = contract.Id,
                HashHex = hash,
                CreatedByUserId = userId
            });

            await db.SaveChangesAsync();
        }
    }
    //TODO: Call LogContractIntegrityAsync when contract becomes FullySigned, but only if not already logged (idempotent):
    //Call this only when status becomes FullySigned:
    //if (contract.Status == ContractStatus.FullySigned && 
    //    !await db.IntegrityLogs.AnyAsync(l => l.ObjectType == "Contract" && l.ObjectId == contract.Id))
    //{
    //            await LogContractIntegrityAsync(contract, db, pdfService, userId);
    // }

}
