using DijitalPazarlama.Data;
using DijitalPazarlama.Managers;
using DijitalPazarlama.Model;
using DijitalPazarlama.Service;
using System;
using System.Windows.Forms;

namespace DijitalPazarlama.Views
{
    public partial class LoginForm : Form
    {
        AppUserService UserService = new AppUserService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadData.LoadUsers();
            LoadData.LoadCategories();
            LoadData.LoadProducts();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserService.isLoginCorrect(txtUsername.Text, txtPassword.Text))
            {
                SessionManager.ActiveUser = UserService.FindByUsername(txtUsername.Text);
                SessionManager.SetInfo();

                if (SessionManager.CurrentUserRole == Role.Admin)
                {
                    AdminPanel adminpanel = new AdminPanel(this);
                    adminpanel.Show();
                }
                else
                {
                    UserPanel userpanel = new UserPanel(this);
                    userpanel.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp f1 = new SignUp(this);
            f1.Show();
            this.Hide();
        }
    }
}
