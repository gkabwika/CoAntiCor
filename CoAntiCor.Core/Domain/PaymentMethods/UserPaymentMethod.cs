namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{    
    public class UserPaymentMethod
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public Guid? PaymentMethodId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}