using DijitalPazarlama.Factory;
using DijitalPazarlama.Managers;
using DijitalPazarlama.Model;
using DijitalPazarlama.Validation;
using System.Threading;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class BuyProduct : Form
    {
        UserPanel lastform;
        Validator isValid = new Validator();

        public BuyProduct(UserPanel f1)
        {
            lastform = f1;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BuyProduct_Load(object sender, System.EventArgs e)
        {
            lblProductName.Text = ShoppingCart.Product.Name;
            lblProductCount.Text = ShoppingCart.ProductCount.ToString();
            ShoppingCart.TotalPrice = ShoppingCart.Product.price * ShoppingCart.ProductCount;
            lblTotalPrice.Text = ShoppingCart.TotalPrice.ToString();

            txtFullName.Text = SessionManager.Fullname;

            gbCreditCard.Visible = true;
            gbEFT.Visible = false;
        }

        private void BuyProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastform.Show();
        }

        private void rbCreditCard_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbCreditCard.Checked)
            {
                gbCreditCard.Visible = true;
                gbEFT.Visible = false;
            }
            else
            {
                gbCreditCard.Visible = false;
                gbEFT.Visible = true;
            }
        }

        private void btnBuy_Click(object sender, System.EventArgs e)
        {
            if (isValid.ValidateInput(txtFullName.Text, 5) &&
                isValid.ValidateInput(txtAddress.Text, 5) &&
                isValid.ValidateInput(txtTelNo.Text, 1, true, true))
            {
                if (rbCreditCard.Checked)
                {
                    if (isValid.ValidateInput(txtCardName.Text, 5) &&
                        isValid.ValidateInput(txtCardNumber.Text, 1, true, true) &&
                        isValid.ValidateInput(txtMonth.Text, 2, true, true) &&
                        isValid.ValidateInput(txtYear.Text, 4, true, true) &&
                        isValid.ValidateInput(txtCVC.Text, 3, true, true))
                    {
                        ShoppingCart.CreditCardHolder = txtCardName.Text;
                        ShoppingCart.CreditCardNumber = txtCardNumber.Text;
                        ShoppingCart.CardMonth = int.Parse(txtMonth.Text);
                        ShoppingCart.CardYear = int.Parse(txtYear.Text);
                        ShoppingCart.CVC = int.Parse(txtCVC.Text);

                        Cursor.Current = Cursors.WaitCursor;
                        Refresh();
                        Thread.Sleep(5000);
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("Tüm alanları doğru dürüst doldurun");
                        return;
                    }
                }

                ShoppingCart.paymentType = rbCreditCard.Checked ? PaymentType.CreditCard : PaymentType.EFT;
                ShoppingCart.FullName = txtFullName.Text;
                ShoppingCart.Address = txtAddress.Text;
                ShoppingCart.TelNo = txtTelNo.Text;

                PurchaseDetail purchaseDetail = new PurchaseDetail(this);
                this.Hide();
                purchaseDetail.Show();
            }
            else
                MessageBox.Show("Tüm alanları doğru dürüst doldurun");
        }
    }
}
