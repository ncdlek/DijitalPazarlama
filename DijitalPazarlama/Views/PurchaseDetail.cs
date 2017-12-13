using DijitalPazarlama.Model;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class PurchaseDetail : Form
    {
        BuyProduct lastform;

        public PurchaseDetail(BuyProduct f1)
        {
            lastform = f1;

            InitializeComponent();
        }

        private void PurchaseDetail_Load(object sender, System.EventArgs e)
        {
            lblProductName.Text = ShoppingCart.Product.Name;
            lblProductCount.Text = ShoppingCart.ProductCount.ToString();
            lblTotalPrice.Text = ShoppingCart.TotalPrice.ToString();
            lblPaymentMethod.Text = ShoppingCart.paymentType.ToString();

            txtFullName.Text = ShoppingCart.FullName;
            txtAddress.Text = ShoppingCart.Address;
            txtTelNo.Text = ShoppingCart.TelNo;
        }

        private void PurchaseDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastform.Show();
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
