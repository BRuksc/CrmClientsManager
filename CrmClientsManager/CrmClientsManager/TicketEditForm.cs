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

namespace CrmClientsManager.UI
{
    public partial class TicketEditForm : Form
    {
        private readonly ITicketService _service;

        private NumericUpDown nudCustomerId;
        private TextBox txtContractId;
        private TextBox txtSubject;
        private TextBox txtDescription;
        private ComboBox cmbPriority;

        private Button btnSave;
        private Button btnCancel;


        public TicketEditForm(
            ITicketService service)
        {
            _service = service;

            InitializeComponent();

            LoadPriority();
        }


        private void InitializeComponent()
        {
            Text = "Add Ticket";
            Size = new Size(500, 500);
            StartPosition = FormStartPosition.CenterParent;


            var lblCustomer =
                new Label()
                {
                    Text = "Customer ID",
                    Location = new Point(30, 30),
                    Width = 120
                };


            nudCustomerId =
                new NumericUpDown()
                {
                    Location = new Point(160, 30),
                    Width = 200,
                    Minimum = 1
                };


            var lblContract =
                new Label()
                {
                    Text = "Contract ID",
                    Location = new Point(30, 70),
                    Width = 120
                };


            txtContractId =
                new TextBox()
                {
                    Location = new Point(160, 70),
                    Width = 200
                };


            var lblSubject =
                new Label()
                {
                    Text = "Subject",
                    Location = new Point(30, 110),
                    Width = 120
                };


            txtSubject =
                new TextBox()
                {
                    Location = new Point(160, 110),
                    Width = 250
                };


            var lblDescription =
                new Label()
                {
                    Text = "Description",
                    Location = new Point(30, 150),
                    Width = 120
                };


            txtDescription =
                new TextBox()
                {
                    Location = new Point(160, 150),
                    Width = 250,
                    Height = 100,
                    Multiline = true
                };


            var lblPriority =
                new Label()
                {
                    Text = "Priority",
                    Location = new Point(30, 270),
                    Width = 120
                };


            cmbPriority =
                new ComboBox()
                {
                    Location = new Point(160, 270),
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };


            btnSave =
                new Button()
                {
                    Text = "Save",
                    Location = new Point(160, 330),
                    Width = 100
                };

            btnCancel =
                new Button()
                {
                    Text = "Cancel",
                    Location = new Point(280, 330),
                    Width = 100
                };


            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;


            Controls.Add(lblCustomer);
            Controls.Add(nudCustomerId);

            Controls.Add(lblContract);
            Controls.Add(txtContractId);

            Controls.Add(lblSubject);
            Controls.Add(txtSubject);

            Controls.Add(lblDescription);
            Controls.Add(txtDescription);

            Controls.Add(lblPriority);
            Controls.Add(cmbPriority);

            Controls.Add(btnSave);
            Controls.Add(btnCancel);
        }


        private void LoadPriority()
        {
            cmbPriority.DataSource =
                Enum.GetValues<TicketPriority>();
        }


        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                var ticket = new Ticket()
                {
                    CustomerId = (int)nudCustomerId.Value,

                    ContractId =
                        string.IsNullOrWhiteSpace(txtContractId.Text)
                        ? null
                        : int.Parse(txtContractId.Text),

                    Subject = txtSubject.Text,

                    Description = txtDescription.Text,

                    Priority =
                        (TicketPriority)cmbPriority.SelectedItem,

                    Status = TicketStatus.New,

                    CreatedDate = DateTime.Now
                };


                _service.Create(ticket);


                MessageBox.Show(
                    "Ticket created.");


                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error");
            }
        }


        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}