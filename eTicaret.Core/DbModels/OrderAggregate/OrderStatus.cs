using System.Runtime.Serialization;

namespace eTicaret.Core.DbModels.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending, 
        [EnumMember(Value = "Payment Recevied")]
        PaymentRecevied,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
