﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace project_CinemaManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;
            int result = Login(userName, passWord);
            if (result == 1)
            {
                Account loginAccount = AccountDAO.GetAccountByUserName(userName);
                frmAdmin frm = new frmAdmin(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else if (result == 0)
            {
                MessageBox.Show("SAI TÊN TÀI KHOẢN HOẶC MẬT KHẨU!!!!", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
            }
            btnLogin.Enabled = true;
       
        }

        private int Login(string userName, string passWord)
        {
            return AccountDAO.Login(userName, passWord);
        }

        private void mnuSetting_Click(object sender, EventArgs e)
        {

        }
    }
}