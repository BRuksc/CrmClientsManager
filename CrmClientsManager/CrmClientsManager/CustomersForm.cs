using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrmClientsManager.UI
{
    public partial class CustomersForm : Form
    {
        private readonly ICustomerService _service;

        private DataGridView dgvCustomers;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;


        public CustomersForm(ICustomerService service)
        {
            _service = service;

            InitializeComponent();

            LoadCustomers();
        }


        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            dgvCustomers.Location = new Point(20, 60);
            dgvCustomers.Size = new Size(800, 300);
            dgvCustomers.AutoGenerateColumns = true;

            txtSearch.Location = new Point(20, 20);
            txtSearch.Width = 250;

            btnSearch.Text = "Search";
            btnSearch.Location = new Point(280, 20);
            btnSearch.Click += btnSearch_Click;

            btnAdd.Text = "Add";
            btnAdd.Location = new Point(20, 380);
            btnAdd.Click += btnAdd_Click;

            btnEdit.Text = "Edit";
            btnEdit.Location = new Point(120, 380);
            btnEdit.Click += btnEdit_Click;

            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(220, 380);
            btnDelete.Click += btnDelete_Click;

            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvCustomers);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);

            Text = "Customers";
            Size = new Size(900, 500);
        }

        private void LoadCustomers()
        {
            dgvCustomers.DataSource =
                _service.GetCustomers();
        }


        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            var text = txtSearch.Text;

            dgvCustomers.DataSource =
                _service.GetCustomers()
                .Where(x =>
                    x.Name.Contains(text,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    x.Nip.Contains(text))
                .ToList();
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
                return;


            var customer =
                (Customer)dgvCustomers
                .CurrentRow
                .DataBoundItem;


            var result =
                MessageBox.Show(
                    $"Delete customer {customer.Name}?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (result != DialogResult.Yes)
                return;

                _service.Delete(customer.CustomerId);

                LoadCustomers();

                MessageBox.Show(
                    "Customer deleted.");
        }

        private void btnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
                return;


            var customer =
                (Customer)dgvCustomers
                .CurrentRow
                .DataBoundItem;


            using var form = new CustomerEditForm(_service, customer);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            using var form =
                new CustomerEditForm(_service);


            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }
    }
}
