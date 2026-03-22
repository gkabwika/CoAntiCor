namespace CoAntiCor.Core.Domain.PaymentMethods
{    
    public class UserPaymentMethod : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public Guid? PaymentMethodId { get; set; }
    }
}