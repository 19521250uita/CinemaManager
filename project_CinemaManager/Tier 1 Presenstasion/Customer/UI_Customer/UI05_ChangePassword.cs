﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
namespace project_CinemaManager
{
    public partial class UI05_ChangePassword : Form
    {
        public UI05_ChangePassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtNewPass.Text != "" && txtOldPass.Text != "")
            {
                try
                {
                    if (AccountDB.UpdatePasswordForAccount(UICustomerInfo.loginAccount.UserName, txtOldPass.Text, txtNewPass.Text))
                    {
                        MessageBox.Show("Đổi Mật Khẩu Thành Công!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi Mật Khẩu Thất Bại!!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Đổi Mật Khẩu Thất Bại!!");
                }
            }
            else
            {
                MessageBox.Show("Xin Hãy Nhập Mật Khẩu!!");
            }
        }

        private void btnConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            }
        }
    }
}
