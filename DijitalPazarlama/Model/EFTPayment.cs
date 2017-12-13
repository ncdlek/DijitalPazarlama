using System.Threading;

namespace DijitalPazarlama.Model
{
    class EFTPayment : Payment
    {
        public override void Pay()
        {
            Thread.Sleep(3000);
        }
    }
}
