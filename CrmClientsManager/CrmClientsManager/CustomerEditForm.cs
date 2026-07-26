using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CrmClientsManager.UI
{
    public partial class CustomerEditForm : Form
    {
        private readonly ICustomerService _service;
        private readonly Customer? _customer;

        private TextBox txtName;
        private TextBox txtNip;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtPhone;

        private ComboBox cmbType;
        private Button btnSave;


        public CustomerEditForm(
            ICustomerService service)
        {
            _service = service;

            InitializeComponent();
        }

        public CustomerEditForm(ICustomerService service, Customer customer)
        {
            _service = service;
            _customer = customer;

            InitializeComponent();
        }


        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtNip = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();

            cmbType = new ComboBox();

            btnSave = new Button();


            txtName.Location = new Point(20, 20);
            txtName.Width = 250;
            txtName.PlaceholderText = "Name";


            txtNip.Location = new Point(20, 60);
            txtNip.Width = 250;
            txtNip.PlaceholderText = "NIP";


            txtAddress.Location = new Point(20, 100);
            txtAddress.Width = 250;
            txtAddress.PlaceholderText = "Address";


            txtEmail.Location = new Point(20, 140);
            txtEmail.Width = 250;
            txtEmail.PlaceholderText = "Email";


            txtPhone.Location = new Point(20, 180);
            txtPhone.Width = 250;
            txtPhone.PlaceholderText = "Phone";


            cmbType.Location = new Point(20, 220);
            cmbType.Width = 250;
            cmbType.DataSource =
                Enum.GetValues<CustomerType>();


            btnSave.Location = new Point(20, 270);
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;


            Controls.Add(txtName);
            Controls.Add(txtNip);
            Controls.Add(txtAddress);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(cmbType);
            Controls.Add(btnSave);


            Text = "Add Customer";
            Size = new Size(350, 380);
        }


        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            if (_customer == null)
            {
                var customer = new Customer()
                {
                    Name = txtName.Text,
                    Nip = txtNip.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Type =
                        (CustomerType)cmbType.SelectedItem
                };


                _service.Create(customer);


                MessageBox.Show(
                    "Customer created");


                Close();
            }
            else
            {
                _customer.CustomerId = _customer.CustomerId;

                _service.Update(_customer);

                MessageBox.Show(
                    "Customer updated.");
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
