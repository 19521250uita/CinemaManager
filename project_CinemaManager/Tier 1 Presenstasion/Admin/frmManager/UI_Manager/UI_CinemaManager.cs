﻿using DB;
using System;
using System.Windows.Forms;

namespace frmAdminUserControls
{
    public partial class CinemaUC : UserControl
    {
        private BindingSource cinemaList = new BindingSource();

        public CinemaUC()
        {
            InitializeComponent();
            LoadCinema();
        }

        private void LoadCinema()
        {
            dtgvCinema.DataSource = cinemaList;
            LoadCinemaList();
            AddCinemaBinding();
        }

        private void LoadCinemaList()
        {
            cinemaList.DataSource = CinemaDAO.GetListCinema();
        }

        private void AddCinemaBinding()
        {
            txtCinemaID.DataBindings.Add("Text", dtgvCinema.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never);
            txtCinemaName.DataBindings.Add("Text", dtgvCinema.DataSource, "Tên phòng", true, DataSourceUpdateMode.Never);
            txtCinemaSeats.DataBindings.Add("Text", dtgvCinema.DataSource, "Số chỗ ngồi", true, DataSourceUpdateMode.Never);
            txtCinemaStatus.DataBindings.Add("Text", dtgvCinema.DataSource, "Tình trạng", true, DataSourceUpdateMode.Never);
            txtNumberOfRows.DataBindings.Add("Text", dtgvCinema.DataSource, "Số hàng ghế", true, DataSourceUpdateMode.Never);
            txtSeatsPerRow.DataBindings.Add("Text", dtgvCinema.DataSource, "Ghế mỗi hàng", true, DataSourceUpdateMode.Never);
            LoadScreenTypeIntoComboBox(cboCinemaScreenType);
        }

        private void LoadScreenTypeIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = ScreenTypeDAO.GetListScreenType();
            cbo.DisplayMember = "Name";
            cbo.ValueMember = "ID";
        }

        private void InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if (CinemaDAO.InsertCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Thêm phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Thêm phòng chiếu thất bại");
            }
        }

        private void UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if (CinemaDAO.UpdateCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Sửa phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Sửa phòng chiếu thất bại");
            }
        }

        private void DeleteCinema(string id)
        {
            if (CinemaDAO.DeleteCinema(id))
            {
                MessageBox.Show("Xóa phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Xóa phòng chiếu thất bại");
            }
        }

        private void btnInsertCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            string cinemaName = txtCinemaName.Text;
            string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus = int.Parse(txtCinemaStatus.Text);
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            InsertCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
            LoadCinemaList();
        }

        private void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            DeleteCinema(cinemaID);
            LoadCinemaList();
        }

        private void btnUpdateCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            string cinemaName = txtCinemaName.Text;
            string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus = int.Parse(txtCinemaStatus.Text);
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            UpdateCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
            LoadCinemaList();
        }

        private void btnShowCinema_Click(object sender, EventArgs e)
        {
            LoadCinemaList();
        }
    }
}