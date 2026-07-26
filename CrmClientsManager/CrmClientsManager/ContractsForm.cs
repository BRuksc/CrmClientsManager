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
    public partial class ContractsForm : Form
    {
        private readonly IContractService _service;

        private readonly int _customerId;

        private DataGridView dgvContracts;


        public ContractsForm(
            IContractService service,
            int customerId)
        {
            _service = service;
            _customerId = customerId;

            InitializeComponent();

            LoadContracts();
        }


        private void InitializeComponent()
        {
            dgvContracts = new DataGridView();

            dgvContracts.Location =
                new Point(20, 20);

            dgvContracts.Size =
                new Size(800, 350);

            dgvContracts.AutoGenerateColumns = true;


            Controls.Add(dgvContracts);


            Text = "Contracts";
            Size = new Size(900, 450);
        }


        private void LoadContracts()
        {
            dgvContracts.DataSource =
                _service.GetByCustomerId(
                    _customerId);
        }
    }
}
