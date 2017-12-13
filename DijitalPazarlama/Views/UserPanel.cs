using DijitalPazarlama.Data;
using DijitalPazarlama.Model;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class UserPanel : Form
    {
        LoginForm mainform;
        public UserPanel(LoginForm f1)
        {
            mainform = f1;
            InitializeComponent();
        }

        private void UserPanel_Load(object sender, System.EventArgs e)
        {
            foreach (var item in Database.Categories)
                lbCategories.Items.Add(item);
            lbCategories.SelectedIndex = 0;
        }

        private void UserPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void lbCategories_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lbProducts.Items.Clear();
            pbProduct.Image = null;
            lblProductPrice.Text = "0 TL";
            txtProductDescription.Text = "";
            numCount.Value = 1;

            foreach (var item in Database.Products)
            {
                if ((lbCategories.SelectedItem as Category).Id == item.CategoryId)
                    lbProducts.Items.Add(item);
            }

            if (lbProducts.Items.Count > 0)
                lbProducts.SelectedIndex = 0;
        }

        private void lbProducts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Product product = (lbProducts.SelectedItem as Product);
            pbProduct.ImageLocation = product.PictureName;
            txtProductDescription.Text = product.Description;
            lblProductPrice.Text = product.price.ToString() + "TL";
            numCount.Value = 1;
        }

        private void btnBuy_Click(object sender, System.EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1 && numCount.Value > 0)
            {
                BuyProduct f1 = new BuyProduct(this);

                ShoppingCart.Product = (lbProducts.SelectedItem as Product);
                ShoppingCart.ProductCount = numCount.Value;

                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ürün seçiniz!");
            }
            
        }
    }
}
