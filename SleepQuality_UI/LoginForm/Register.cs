using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            txtEmail.GotFocus += RemoveText;
            txtEmail.LostFocus += AddText;

            txtPassword.GotFocus += RemoveText;
            txtPassword.LostFocus += AddText;

            txtAddress.GotFocus += RemoveText;
            txtAddress.LostFocus += AddText;

            txtPhone.GotFocus += RemoveText;
            txtPhone.LostFocus += AddText;

            txtConfirmPass.GotFocus += RemoveText;
            txtConfirmPass.LostFocus += AddText;

            txtSurname.GotFocus += RemoveText;
            txtSurname.LostFocus += AddText;

            txtName.GotFocus += RemoveText;
            txtName.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "Email")
            {
                txtEmail.ForeColor = Color.Black;
                txtEmail.Text = "";
            }

            if ((sender as TextBox).Text == "Name")
            {
                txtName.ForeColor = Color.Black;
                txtName.Text = "";
            }

            if ((sender as TextBox).Text == "Surname")
            {
                txtSurname.ForeColor = Color.Black;
                txtSurname.Text = "";
            }

            if ((sender as TextBox).Text == "Address")
            {
                txtAddress.ForeColor = Color.Black;
                txtAddress.Text = "";
            }

            if ((sender as TextBox).Text == "Phone Number")
            {
                txtPhone.ForeColor = Color.Black;
                txtPhone.Text = "";
            }

            if ((sender as TextBox).Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.Black;
                txtPassword.Text = "";
            }
            if ((sender as TextBox).Text == "Confirm Password")
            {
                txtConfirmPass.UseSystemPasswordChar = true;
                txtConfirmPass.ForeColor = Color.Black;
                txtConfirmPass.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = SystemColors.Control;

            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Name";
                txtName.ForeColor = SystemColors.Control;

            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.Text = "Phone Number";
                txtPhone.ForeColor = SystemColors.Control;

            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.Text = "Address";
                txtAddress.ForeColor = SystemColors.Control;

            }
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                txtSurname.Text = "Surname";
                txtSurname.ForeColor = SystemColors.Control;

            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;

                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.Control;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                txtConfirmPass.UseSystemPasswordChar = false;

                txtConfirmPass.Text = "Confirm Password";
                txtConfirmPass.ForeColor = SystemColors.Control;

            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            this.Hide();
            form.ShowDialog();
        }
    }
}
