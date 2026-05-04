using System.Windows.Forms;
using Demoexam.Models;
using Demoexam.Database;

namespace Demoexam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("Photos/Icon.ico");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            var user = db.Users.FirstOrDefault(u => u.Login == txtLogin.Text && u.Password == txtPassword.Text);
            if (user != null) OpenMain(user);
            else MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            OpenMain(new User { Fullname = "Гость", Role = "Гость" });
        }

        private void OpenMain(User user)
        {
            Hide();
            txtLogin.Clear();
            txtPassword.Clear();

            var main = new MainForm(user, this);
            main.Show();
        }
    }
}
