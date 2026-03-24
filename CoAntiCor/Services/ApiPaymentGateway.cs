using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Document;
using CoAntiCor.Core.Domain.Payment;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Services;

namespace CoAntiCor.Services
{
   // public class ApiPaymentGateway : IPaymentGateway
    public class ApiPaymentGateway 
    {
        private readonly ApiClient _api;

        //public ApiPaymentGateway(ApiClient api)
        //{
        //    _api = api;
        //}

        //public async Task<PaymentStartResult> StartPaymentAsync(PaymentStartDto dto)
        //{
        //    return await _api.PostAsync<PaymentStartResult>("/api/Payment/Start", dto);
        //}

        //public async Task<PaymentStatusDto> GetStatusAsync(Guid paymentId)
        //{
        //    return await _api.GetAsync<PaymentStatusDto>($"/api/Payment/Status?paymentId={paymentId}");
        //}
    }


}
