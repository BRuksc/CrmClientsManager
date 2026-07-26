using CrmClientsManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrmClientsManager.UI
{
    public partial class DashboardForm : Form
    {
        private readonly IDashboardService _service;


        private Label lblCustomers;
        private Label lblContracts;
        private Label lblTickets;


        public DashboardForm(
            IDashboardService service)
        {
            _service = service;

            InitializeComponent();

            LoadDashboard();
        }


        private void InitializeComponent()
        {
            lblCustomers = new Label();
            lblContracts = new Label();
            lblTickets = new Label();


            lblCustomers.Location =
                new Point(30, 30);

            lblCustomers.AutoSize = true;


            lblContracts.Location =
                new Point(30, 80);

            lblContracts.AutoSize = true;


            lblTickets.Location =
                new Point(30, 130);

            lblTickets.AutoSize = true;


            Controls.Add(lblCustomers);
            Controls.Add(lblContracts);
            Controls.Add(lblTickets);


            Text = "Dashboard";
            Size = new Size(500, 250);
        }


        private void LoadDashboard()
        {
            var data =
                _service.GetDashboardData();


            lblCustomers.Text =
                $"Active customers: {data.ActiveCustomersCount}";


            lblContracts.Text =
                $"Expiring contracts: {data.ExpiringContractsCount}";


            lblTickets.Text =
                $"Open tickets: " +
                $"High: {data.HighPriorityOpenTicketsCount}, " +
                $"Medium: {data.MediumPriorityOpenTicketsCount}, " +
                $"Low: {data.LowPriorityOpenTicketsCount}";
        }
    }
}
