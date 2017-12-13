using DijitalPazarlama.Data;
using DijitalPazarlama.Service;
using DijitalPazarlama.Validation;
using System;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class SignUp : Form
    {
        LoginForm mainform;
        Validator isValid = new Validator();
        AppUserService UserService = new AppUserService();
        public SignUp(LoginForm f)
        {
            mainform = f;
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (UserService.isExistingUser(txtUsername.Text) &&
                isValid.ValidateInput(txtUsername.Text, 2) &&
                isValid.ValidateInput(txtPassword.Text, 2) &&
                isValid.ValidateInput(txtName.Text, 2) &&
                isValid.ValidateInput(txtLastname.Text, 2))
            {
                SaveData.SaveUser(txtName.Text, txtLastname.Text, txtUsername.Text, txtPassword.Text);
                MessageBox.Show("Başarıyla üye oldunuz! Ana ekrandan giriş yapabilirsiniz.", "Kayıt başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hata!\r\nOlası sebepler:\r\n1- Alanlar boş geçilemez ve minimum uzunluk 4 karakter olmalıdır.\r\n2- Kullanıcı adı başka bir kullanıcı tarafından kullanılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }
    }
}
