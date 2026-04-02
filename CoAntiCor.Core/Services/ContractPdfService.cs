using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using QuestPDF.Fluent;



namespace CoAntiCor.Core.Services
{
    /// <summary>
    ///  PDF generation service (using QuestPDF as example)
    ///  QuestPDF is a production-ready library that lets you design documents the way you design software: 
    ///  with clean, maintainable, strong-typed C# code. Stop fighting with HTML-to-PDF conversion. 
    ///  Build pixel-perfect reports, invoices, and exports using the language and tools you already love.
    /// </summary>
    public class ContractPdfService : IContractPdfService
    {
        public byte[] Generate(Contract contract)
        {
            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Content().Column(col =>
                    {
                        col.Item().Text(contract.ContractNumber).FontSize(18).Bold();
                        col.Item().Text(contract.HtmlBody).FontSize(11);
                        col.Item().Text($"Status: {contract.Status}");
                        if (contract.BuyerSignature != null)
                            col.Item().Text($"Buyer signed at: {contract.BuyerSignedAtUtc:O}");
                        if (contract.SellerSignature != null)
                            col.Item().Text($"Seller signed at: {contract.SellerSignedAtUtc:O}");
                    });
                });
            });

            return doc.GeneratePdf();
        }
    }

}
