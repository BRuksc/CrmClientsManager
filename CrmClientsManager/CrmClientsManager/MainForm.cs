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
    public partial class MainForm : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IContractService _contractService;
        private readonly ITicketService _ticketService;
        private readonly IDashboardService _dashboardService;


        private Button btnCustomers;
        private Button btnTickets;
        private Button btnDashboard;


        public MainForm(
            ICustomerService customerService,
            IContractService contractService,
            ITicketService ticketService,
            IDashboardService dashboardService)
        {
            _customerService = customerService;
            _contractService = contractService;
            _ticketService = ticketService;
            _dashboardService = dashboardService;

            InitializeComponent();
        }


        private void InitializeComponent()
        {
            btnCustomers = new Button();
            btnTickets = new Button();
            btnDashboard = new Button();


            btnCustomers.Text = "Customers";
            btnCustomers.Location = new Point(50, 50);
            btnCustomers.Size = new Size(150, 40);

            btnCustomers.Click += btnCustomers_Click;


            btnTickets.Text = "Tickets";
            btnTickets.Location = new Point(50, 110);
            btnTickets.Size = new Size(150, 40);

            btnTickets.Click += btnTickets_Click;


            btnDashboard.Text = "Dashboard";
            btnDashboard.Location = new Point(50, 170);
            btnDashboard.Size = new Size(150, 40);

            btnDashboard.Click += btnDashboard_Click;


            Controls.Add(btnCustomers);
            Controls.Add(btnTickets);
            Controls.Add(btnDashboard);


            Text = "CRM Manager";
            Size = new Size(300, 300);
        }


        private void btnCustomers_Click(
            object sender,
            EventArgs e)
        {
            using var form =
                new CustomersForm(_customerService);

            form.ShowDialog();
        }


        private void btnTickets_Click(
            object sender,
            EventArgs e)
        {
            using var form =
                new TicketsForm(_ticketService);

            form.ShowDialog();
        }


        private void btnDashboard_Click(
            object sender,
            EventArgs e)
        {
            using var form =
                new DashboardForm(_dashboardService);

            form.ShowDialog();
        }
    }
}
