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

    public partial class TicketsForm : Form
    {
        private readonly ITicketService _service;


        private DataGridView dgvTickets;
        private Button btnRefresh;
        private Button btnClose;
        private Button btnAdd;


        public TicketsForm(
            ITicketService service)
        {
            _service = service;

            InitializeComponent();

            LoadTickets();
        }


        private void InitializeComponent()
        {
            dgvTickets = new DataGridView();

            btnRefresh = new Button();
            btnClose = new Button();
            btnAdd = new Button();

            dgvTickets.Location =
                new Point(20, 20);

            dgvTickets.Size =
                new Size(850, 300);


            btnRefresh.Text = "Refresh";
            btnRefresh.Location =
                new Point(20, 340);

            btnRefresh.Click +=
                (s, e) => LoadTickets();



            btnClose.Text = "Close ticket";
            btnClose.Location =
                new Point(120, 340);

            btnAdd.Text = "Add ticket";
            btnAdd.Location = new Point(220, 340);

            btnAdd.Click += btnAdd_Click;

            btnClose.Click +=
                btnClose_Click;

            Controls.Add(dgvTickets);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(btnAdd);

            Text = "Tickets";
            Size = new Size(950, 450);
        }


        private void LoadTickets()
        {
            dgvTickets.DataSource =
                _service.GetOpen();
        }


        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            if (dgvTickets.CurrentRow == null)
                return;


            var ticket =
                (Ticket)dgvTickets
                .CurrentRow
                .DataBoundItem;


            _service.Close(
                ticket.TicketId,
                DateTime.Now,
                "Closed from application");


            LoadTickets();
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            using var form =
                new TicketEditForm(_service);


            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTickets();
            }
        }
    }
}
