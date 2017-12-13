using System.Threading;

namespace DijitalPazarlama.Model
{
    class CreditCardPayment : Payment
    {
        public override void Pay()
        {
            Thread.Sleep(3000);
        }
    }
}
