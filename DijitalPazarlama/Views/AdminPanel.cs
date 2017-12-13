using DijitalPazarlama.Data;
using DijitalPazarlama.Model;
using DijitalPazarlama.Validation;
using System;
using System.IO;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class AdminPanel : Form
    {
        LoginForm mainform;
        Validator isValid = new Validator();
        string filepath, filename;
        decimal price;
        public AdminPanel(LoginForm f1)
        {
            mainform = f1;
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            SaveData.SaveCategory(txtCategory.Text, txtCategoryDescription.Text);
            lbCategories.Items.Clear();
            foreach (var item in Database.Categories)
                lbCategories.Items.Add(item);
            lbCategories.SelectedIndex = 0;

            txtCategory.Text = "";
            txtCategoryDescription.Text = "";
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            foreach (var item in Database.Categories)
                lbCategories.Items.Add(item);
            lbCategories.SelectedIndex = 0;
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbProducts.Items.Clear();

            foreach (var item in Database.Products)
            {
                if ((lbCategories.SelectedItem as Category).Id == item.CategoryId)
                    lbProducts.Items.Add(item);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool b = decimal.TryParse(txtPrice.Text, out price);
            if (isValid.ValidateInput(txtProduct.Text, 2) &&
                isValid.ValidateInput(txtProductDescription.Text, 5) &&
                lbCategories.SelectedIndex != -1 &&
                b &&
                !string.IsNullOrWhiteSpace(filename))
            {
                SaveData.SaveProduct(txtProduct.Text, txtProductDescription.Text, (lbCategories.SelectedItem as Category).Id, price, filename, filepath);
                MessageBox.Show("Ürün eklendi!");

                pictureBox1.Image = null;
                filepath = "";
                filename = "";
                txtProduct.Text = "";
                txtProductDescription.Text = "";

                lbProducts.Items.Clear();
                foreach (var item in Database.Products)
                {
                    if ((lbCategories.SelectedItem as Category).Id == item.CategoryId)
                        lbProducts.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurunuz ve bir kategori seçiniz!");
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult dr = ofd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    filename = ofd.SafeFileName;
                    filepath = ofd.FileName;
                    
                    pictureBox1.ImageLocation = filepath;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                    MessageBox.Show("Dosya seçmediniz.");
            }
        }
    }
}
