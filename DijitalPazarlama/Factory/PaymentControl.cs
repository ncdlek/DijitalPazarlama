using DijitalPazarlama.Model;

namespace DijitalPazarlama.Factory
{
    public enum PaymentType
    {
        CreditCard,
        EFT
    }

    public class PaymentControl
    {
        public Payment ChoosePaymentMethod(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.CreditCard:
                    return new CreditCardPayment();
                case PaymentType.EFT:
                    return new EFTPayment();
            }

            return new CreditCardPayment();
        }
    }
}
